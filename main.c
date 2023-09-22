#include <stdio.h>
#include <string.h>
#include "stdlib.h"
#include "pico/stdlib.h"
#include "pico/bootrom.h"
#include "pico/binary_info.h"
#include "pico/time.h"
#include "hardware/pwm.h"
#include "hardware/pio.h"
#include "hardware/gpio.h"
#include "hardware/timer.h"
#include "quadrature_encoder.pio.h"

#define A_PIN 8		// PIN xuat pwm
#define B_PIN 9
#define WRAP 65535	// WRAP+1 la chu ki PWM
#define EN_A 10		// PIN encoder
#define EN_B 11
#define PPR 1320	//so xung toi da cua encoder
#define SAMPLE_TIME 10// Thoi gian lay mau ms
#define PWM_FREQ 50  // Tần số PWM mong muốn (Hz)

#define LED_PIN 25

#define BUFFER_SIZE 34


PIO pio = pio0;
const uint sm = 0;
float Sp, Kp=0.2, Ki = 0, Kd=0;
uint8_t buffer[BUFFER_SIZE];
uint64_t new_time, old_time;

typedef struct{
float ek_1;
float ek_2;
float uk_1;
} PID_t;
PID_t thong_so_PID;

int encoder_1;
int duty_cyclePWM;
float speed;
uint slice_num1;
uint slice_num2;

float PID_controller(float sp, float pv, PID_t *pid)
{
float ek,uk;
ek = sp-pv;
uk = pid->uk_1 + Kp*(ek - pid->ek_1) + Ki*SAMPLE_TIME*(ek + pid->ek_1)*0.5 +Kd*(ek - 2*pid->ek_1 + pid->ek_2)/SAMPLE_TIME;   
pid-> uk_1 = uk;
pid-> ek_1 = ek;
pid-> ek_2 = pid-> ek_1;
return uk; // giá trị uk trả về là duty cycle của xung PWM
}

int chieu;

bool repeating_timer_callback(struct repeating_timer *t) {
    int encoder;
	// note: thanks to two's complement arithmetic delta will always
    // be correct even when new_value wraps around MAXINT / MININT
	encoder= quadrature_encoder_get_count(pio, sm);
	new_time = time_us_64(); // gan gia tr? thoi gian hien tai
	speed = (encoder -encoder_1)/((new_time-old_time)*1e-6)*60/1320;// thu nguyen rpm
	encoder_1 = encoder;
	old_time = new_time;
    printf(" %f \r\n",speed);
	if (chieu ==1)
	{
	float h = PID_controller(Sp, speed, &thong_so_PID);
    if (h>1) h=1;
    if (h<-1) h=0.2;
    pwm_set_chan_level(slice_num1, PWM_CHAN_A, 0); // quay thuan
    pwm_set_chan_level(slice_num2, PWM_CHAN_B, h* 20000 ); // quay thuan
	}
	if (chieu == 0)
	{
		float h = PID_controller(Sp, speed, &thong_so_PID);
    if (h>1) h=0.2;
    if (h<-1) h=1;
    pwm_set_chan_level(slice_num1, PWM_CHAN_A, h* 20000 ); // quay nghich
    pwm_set_chan_level(slice_num2, PWM_CHAN_B, 0); // quay nghich
	}
    return true;
}

double ConvertByteToDouble(uint8_t *str) {
	char string[8];
	for (int i = 0; i < 7; i++) {
	string[i] = (char)str[i];
	}
	double d;
	d = atof(string);
	return d;
}

void buffer_received() {
uint8_t rcvByte[8];
	for (int loop = 0; loop < 8; loop++)
		rcvByte[loop] = buffer[3 + loop];
	Sp = ConvertByteToDouble(rcvByte);
}

void buffer_received_PID() {
uint8_t rcvByte[8];
	for (int loop = 0; loop < 8; loop++)
		rcvByte[loop] = buffer[11 + loop];
	Kp = ConvertByteToDouble(rcvByte);

	for (int loop = 0; loop < 8; loop++)
		rcvByte[loop] = buffer[19 + loop];
	Ki = ConvertByteToDouble(rcvByte);

	for (int loop = 0; loop < 8; loop++)
		rcvByte[loop] = buffer[27 + loop];
	Kd = ConvertByteToDouble(rcvByte);

}

int main() {
 	stdio_init_all();	
    gpio_init(LED_PIN );
	gpio_set_dir(LED_PIN , GPIO_OUT);

	// PWM-------------------------------------------------------------------
     gpio_set_function(A_PIN, GPIO_FUNC_PWM);    // Đặt chức năng của chân GPIO thành PWM
     slice_num1 = pwm_gpio_to_slice_num(A_PIN);    // Lấy số slice tương ứng với chân GPIO
     gpio_set_function(B_PIN, GPIO_FUNC_PWM);   
     slice_num2 = pwm_gpio_to_slice_num(B_PIN);

    pwm_config config = pwm_get_default_config();
    pwm_config_set_wrap(&config, 1e6 / PWM_FREQ);    // Cài đặt wrap (giá trị tối đa) dựa trên tần số, wrap_max =1e6/50


    pwm_init(slice_num1, &config, true);    // Khởi tạo PWM với cấu hình và sử dụng phạm vi đầy đủ của wrap
    pwm_set_enabled(slice_num1, true);    // Bật module PWM
    pwm_init(slice_num2, &config, true);   
    pwm_set_enabled(slice_num2, true);    
   
   	// // ENCODER-----------------------------------------------------------------
    const uint PIN_AB = EN_A;
    uint offset = pio_add_program(pio, &quadrature_encoder_program);
    quadrature_encoder_program_init(pio, sm, offset, PIN_AB, 0);
	struct repeating_timer timer;
    add_repeating_timer_ms(SAMPLE_TIME, repeating_timer_callback, NULL, &timer);

	// //LOOP-------------------------------------------------------------
	pwm_set_chan_level(slice_num1, PWM_CHAN_A, 0); 
    pwm_set_chan_level(slice_num2, PWM_CHAN_B, 15000 ); 
	int value;
	 while(1)
    {
/////////////////////
	scanf("%35s", buffer);
	if (buffer[0]='S')  gpio_put(LED_PIN , !gpio_get(LED_PIN));
	if (buffer[2]=='1')
	{
     buffer_received_PID();
	}

	if (buffer[1]=='0')
	{
    chieu =0;
    buffer_received();
	}
	else if (buffer[1]=='1')
	{
    chieu =1;
    buffer_received();
	}
////////////////////
}
}	


