cmake_minimum_required(VERSION 3.21)

include(pico_sdk_import.cmake)

project(test_project C CXX ASM)
set(CMAKE_C_STANDARD 11)
set(CMAKE_CXX_STANDARD 17)
pico_sdk_init()

add_executable(main
    main.c
)

pico_generate_pio_header(main ${CMAKE_CURRENT_LIST_DIR}/quadrature_encoder.pio)

target_sources(main PRIVATE main.c)

target_link_libraries(main PRIVATE
        pico_stdlib
        pico_multicore
        hardware_pwm
        hardware_pio
        )

pico_enable_stdio_usb(main 1) 
pico_enable_stdio_uart(main 1)

pico_add_extra_outputs(main)


# set(PICO_EXAMPLES_PATH ${PROJECT_SOURCE_DIR})
# include(example_auto_set_url.cmake)
# if (NOT PICO_NO_HARDWARE)
#     add_subdirectory(encoder)
# endif ()
