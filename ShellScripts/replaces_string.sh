#!/bin/bash

# ARGUMENTS
## old_string : Old string to be replaced
## new_string : New string to replace occurrences of old_string

old_string="$1"
new_string="$2"

# Finding and replacing the string in all files within the specified directory
find ./ -type f -exec sed -i "s/${old_string}/${new_string}/g" {} +
