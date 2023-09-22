# Distributed under the OSI-approved BSD 3-Clause License.  See accompanying
# file Copyright.txt or https://cmake.org/licensing for details.

cmake_minimum_required(VERSION 3.5)

file(MAKE_DIRECTORY
  "C:/VSARM/sdk/pico/pico-sdk/tools/pioasm"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/tmp"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/src/PioasmBuild-stamp"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/src"
  "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/src/PioasmBuild-stamp"
)

set(configSubDirs )
foreach(subDir IN LISTS configSubDirs)
    file(MAKE_DIRECTORY "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/src/PioasmBuild-stamp/${subDir}")
endforeach()
if(cfgdir)
  file(MAKE_DIRECTORY "C:/VSARM/sdk/pico/pico-motor-control-usb/pioasm/src/PioasmBuild-stamp${cfgdir}") # cfgdir has leading slash
endif()
