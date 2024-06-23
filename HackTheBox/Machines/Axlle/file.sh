#!/bin/bash

# List of usernames to test
usernames=("root" "admin" "administrator" "webadmin" "sysadmin" "netadmin" "guest" "user" "web" "test" "accounts")

# Loop through each username
for user in "${usernames[@]}"
do
    echo "Testing user: $user"
    swaks --to accounts@axlle.htb --from "$user@axlle.htb" --header "Subject: Test Email" --body "Testing email to $user."
    echo
done

