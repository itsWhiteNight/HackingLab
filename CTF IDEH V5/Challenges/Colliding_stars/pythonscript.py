import hashlib

def find_collision():
    # Initialize two different strings
    string1 = "Hello, world!"
    string2 = "Goodbye, world!"

    # Calculate the MD5 hash for each string
    hash1 = hashlib.md5(string1.encode()).hexdigest()
    hash2 = hashlib.md5(string2.encode()).hexdigest()

    print(f"Original String 1: {string1}")
    print(f"MD5 Hash 1: {hash1}\n")

    print(f"Original String 2: {string2}")
    print(f"MD5 Hash 2: {hash2}\n")

    # Check if the hashes are the same
    if hash1 == hash2:
        print("Collision found! Both strings have the same MD5 hash.")
    else:
        print("No collision found.")

if __name__ == "__main__":
    find_collision()

