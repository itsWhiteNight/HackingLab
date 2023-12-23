# Advent of Cyber - Day 13 Defense Strategies

## Learning Objectives

- Understand the Diamond Model of Intrusion Analysis
- Identify defensive strategies using the Diamond Model
- Set up firewall rules using uncomplicated firewall (ufw)
- Implement a honeypot for defensive security

## Connecting to the Machine

- **Target Machine**:
  + Given SSH
  - Username: vantwinkle
  - Password: TwinkleStar

## Incident Analysis and Diamond Model

### Diamond Model Components

1. **Adversary**
   - Identified insider threat disrupting the merger.
   - Adversary customer benefiting from the cyberattack.

2. **Victim**
   - Best Festival Company is the target.

3. **Infrastructure**
   - USB drive discovered, disrupting plans.
   - Adversarial infrastructure controlled by adversaries or intermediaries.

4. **Capability**
   - Tactics, techniques, and procedures (TTPs) employed by adversaries.

### Defensive Diamond Model

- **Defensive Capability**
  - Threat hunting: Proactive search for signs of malicious activities.
  - Vulnerability management: Identifying, assessing, and mitigating vulnerabilities.

- **Defensive Infrastructure**
  - Firewalls: Network security device controlling traffic flow.
  - Honeypots: Deceptive mechanisms to lure attackers away.

## Defensive Capability

### Threat Hunting

- Proactive and iterative process led by skilled professionals.
- Regular threat hunts to detect adversaries early.
- Analyzing behavioral patterns and improving incident response.

### Vulnerability Management

- Process of identifying, assessing, prioritizing, and mitigating vulnerabilities.
- Regular vulnerability scanning for early detection.
- Patching or remediating vulnerabilities based on severity.

## Defensive Infrastructure

### Firewall

- Types of firewalls:
  1. Stateless/packet-filtering
  2. Stateful inspection
  3. Proxy service
  4. Web application firewall (WAF)
  5. Next-generation firewall

### Configuring Firewalls with ufw

bash
# Check ufw status
sudo ufw status

# Set default policies
sudo ufw default allow outgoing
sudo ufw default deny incoming

# Allow incoming connections to port 22 (SSH)
sudo ufw allow 22/tcp

# Deny specific IP addresses
sudo ufw deny from 192.168.100.25
sudo ufw deny in on eth0 from 192.168.100.26

# Enable ufw
sudo ufw enable

# Check ufw rules
sudo ufw status verbose

# Resetting ufw
sudo ufw reset

### Honeypot
Honeypot: Cybersecurity mechanism to lure attackers away.
Types: Low-interaction and high-interaction honeypots.
Demonstration using PenTBox:

## Launch PenTBox
cd /HackingLab/tools/pentbox1.8/
./pentbox.rb

# Select option 2 for Network tools
# Select option 3 for Honeypot
# Choose auto or manual configuration



