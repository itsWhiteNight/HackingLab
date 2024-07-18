## Introduction

Security has become a buzzword; every company wants to claim its product or service is secure. But is it?

Before we start discussing the different security principles, it is vital to know the adversary against whom we are protecting our assets. Are you trying to stop a toddler from accessing your laptop? Or are you trying to protect a laptop that contains technical designs worth millions of dollars? Using the exact protection mechanisms against toddlers and industrial espionage actors would be ludicrous. Consequently, knowing our adversary is a must so we can learn about their attacks and start implementing appropriate security controls.

Laptop behind a massive iron door (like a safe door) and a toddler on the other side. (As if putting the laptop in a room-sized safe to protect it from a cute, inquisitive toddler.)

It is impossible to achieve perfect security; no solution is 100% secure. Therefore, we try to improve our security posture to make it more difficult for our adversaries to gain access.

The objective of this room is to:

Explain the security functions: Confidentiality, Integrity and Availability (CIA).
Present the opposite of the security triad, CIA: Disclosure, Alteration, and Destruction/Denial (DAD).
Introduce the fundamental concepts of security models, such as the Bell-LaPadula model.
Explain security principles such as Defence-in-Depth, Zero Trust, and Trust but Verify.
Introduce ISO/IEC 19249.
Explain the difference between Vulnerability, Threat, and Risk.
-----------------------------------------------
## CIA

CIA triangle
Before we can describe something as secure, we need to consider better what makes up security. When you want to judge the security of a system, you need to think in terms of the security triad: confidentiality, integrity, and availability (CIA).

Confidentiality ensures that only the intended persons or recipients can access the data.
Integrity aims to ensure that the data cannot be altered; moreover, we can detect any alteration if it occurs.
Availability aims to ensure that the system or service is available when needed.
A seller with a receipt, adding a zero to the price of an item after a shopper chooses it, thus multiplying the price by ten.

Let’s consider the CIA security triad in the case of placing an order for online shopping:

Confidentiality: During online shopping, you expect your credit card number to be disclosed only to the entity that processes the payment. If you doubt that your credit card information will be disclosed to an untrusted party, you will most likely refrain from continuing with the transaction. Moreover, if a data breach results in the disclosure of personally identifiable information, including credit cards, the company will incur huge losses on multiple levels.
Integrity: After filling out your order, if an intruder can alter the shipping address you have submitted, the package will be sent to someone else. Without data integrity, you might be very reluctant to place your order with this seller.
Availability: To place your online order, you will either browse the store’s website or use its official app. If the service is unavailable, you won’t be able to browse the products or place an order. If you continue to face such technical issues, you might eventually give up and start looking for a different online store.
Let’s consider the CIA as it relates to patient records and related systems:

Confidentiality: According to various laws in modern countries, healthcare providers must ensure and maintain the confidentiality of medical records. Consequently, healthcare providers can be held legally accountable if they illegally disclose their patients’ medical records.
Integrity: If a patient record is accidentally or maliciously altered, it can lead to the wrong treatment being administered, which, in turn, can lead to a life-threatening situation. Hence, the system would be useless and potentially harmful without ensuring the integrity of medical records.
Availability: When a patient visits a clinic to follow up on their medical condition, the system must be available. An unavailable system would mean that the medical practitioner cannot access the patient’s records and consequently won’t know if any current symptoms are related to the patient’s medical history. This situation can make the medical diagnosis more challenging and error-prone.
The emphasis does not need to be the same on all three security functions. One example would be a university announcement; although it is usually not confidential, the document’s integrity is critical.

Beyond CIA
A delivery man with an absurdly large number of pizza boxes and a man at the door saying, I didn’t order that.

Going one more step beyond the CIA security triad, we can think of:

Authenticity: Authentic means not fraudulent or counterfeit. Authenticity is about ensuring that the document/file/data is from the claimed source.
Nonrepudiation: Repudiate means refusing to recognize the validity of something. Nonrepudiation ensures that the original source cannot deny that they are the source of a particular document/file/data. This characteristic is indispensable for various domains, such as shopping, patient diagnosis, and banking.
These two requirements are closely related. The need to tell authentic files or orders from fake ones is indispensable. Moreover, ensuring that the other party cannot deny being the source is vital for many systems to be usable.

In online shopping, depending on your business, you might tolerate attempting to deliver a t-shirt with cash-on-delivery and learn later that the recipient never placed such an order. However, no company can tolerate shipping 1000 cars to discover that the order is fake. In the example of a shopping order, you want to confirm that the said customer indeed placed this order; that’s authenticity. Moreover, you want to ensure they cannot deny placing this order; that’s nonrepudiation.

As a company, if you receive a shipment order of 1000 cars, you need to ensure the authenticity of this order; moreover, the source should not be able to deny placing such an order. Without authenticity and nonrepudiation, the business cannot be conducted.

Parkerian Hexad
In 1998, Donn Parker proposed the Parkerian Hexad, a set of six security elements. They are:

Availability
Utility
Integrity
Authenticity
Confidentiality
Possession
We have already covered four of the above six elements. Let's discuss the remaining two elements:

Utility: Utility focuses on the usefulness of the information. For instance, a user might have lost the decryption key to access a laptop with encrypted storage. Although the user still has the laptop with its disk(s) intact, they cannot access them. In other words, although still available, the information is in a form that is not useful, i.e., of no utility.
Possession: This security element requires that we protect the information from unauthorized taking, copying, or controlling. For instance, an adversary might take a backup drive, meaning we lose possession of the information as long as they have the drive. Alternatively, the adversary might succeed in encrypting our data using ransomware; this also leads to the loss of possession of the data.
---------------------------------------------------------------------
## DAD
The security of a system is attacked through one of several means. It can be via the disclosure of secret data, alteration of data, or destruction of data.

Disclosure is the opposite of confidentiality. In other words, disclosure of confidential data would be an attack on confidentiality.
Alteration is the opposite of Integrity. For example, the integrity of a cheque is indispensable.
Destruction/Denial is the opposite of Availability.
The opposite of the CIA Triad would be the DAD Triad: Disclosure, Alteration, and Destruction.

Consider the previous example of patient records and related systems:

Disclosure: As in most modern countries, healthcare providers must maintain medical records’ confidentiality. As a result, if an attacker succeeds in stealing some of these medical records and dumping them online to be viewed publicly, the health care provider will incur a loss due to this data disclosure attack.
Alteration: Consider the gravity of the situation if the attacker manages to modify patient medical records. This alteration attack might lead to the wrong treatment being administered, and consequently, this alteration attack could be life-threatening.
Destruction/Denial: Consider the case where a medical facility has gone completely paperless. If an attacker manages to make the database systems unavailable, the facility will not be able to function properly. They can go back to paper temporarily; however, the patient records won’t be available. This denial attack would stall the whole facility.
Protecting against disclosure, alteration, and destruction/denial is of utter significance. This protection is equivalent to working to maintain confidentiality, integrity and availability.

Protecting confidentiality and integrity to an extreme can restrict availability, and increasing availability to an extreme can result in losing confidentiality and integrity. Good security principles implementation requires a balance between the three.
-----------------------------------------------------------------
## Fundemental Concepts of Security Models
We have learned that the security triad is represented by Confidentiality, Integrity, and Availability (CIA). One might ask, how can we create a system that ensures one or more security functions? The answer would be in using security models. In this task, we will introduce three foundational security models:

Bell-LaPadula Model
The Biba Integrity Model
The Clark-Wilson Model
Bell-LaPadula Model
The Bell-LaPadula Model aims to achieve confidentiality by specifying three rules:

Simple Security Property: This property is referred to as “no read up”; it states that a subject at a lower security level cannot read an object at a higher security level. This rule prevents access to sensitive information above the authorized level.
Star Security Property: This property is referred to as “no write down”; it states that a subject at a higher security level cannot write to an object at a lower security level. This rule prevents the disclosure of sensitive information to a subject of lower security level.
Discretionary-Security Property: This property uses an access matrix to allow read and write operations. An example access matrix is shown in the table below and used in conjunction with the first two properties.
Subjects	Object A	Object B
Subject 1	Write	No access
Subject 2	Read/Write	Read
The first two properties can be summarized as “write up, read down.” You can share confidential information with people of higher security clearance (write up), and you can receive confidential information from people with lower security clearance (read down).

There are certain limitations to the Bell-LaPadula model. For example, it was not designed to handle file-sharing.

Biba Model
The Biba Model aims to achieve integrity by specifying two main rules:

Simple Integrity Property: This property is referred to as “no read down”; a higher integrity subject should not read from a lower integrity object.
Star Integrity Property: This property is referred to as “no write up”; a lower integrity subject should not write to a higher integrity object.
These two properties can be summarized as “read up, write down.” This rule is in contrast with the Bell-LaPadula Model, and this should not be surprising as one is concerned with confidentiality while the other is with integrity.

Biba Model suffers from various limitations. One example is that it does not handle internal threats (insider threat).

Clark-Wilson Model
The Clark-Wilson Model also aims to achieve integrity by using the following concepts:

Constrained Data Item (CDI): This refers to the data type whose integrity we want to preserve.
Unconstrained Data Item (UDI): This refers to all data types beyond CDI, such as user and system input.
Transformation Procedures (TPs): These procedures are programmed operations, such as read and write, and should maintain the integrity of CDIs.
Integrity Verification Procedures (IVPs): These procedures check and ensure the validity of CDIs.
We covered only three security models. The reader can explore many additional security models. Examples include:

Brewer and Nash model
Goguen-Meseguer model
Sutherland model
Graham-Denning model
Harrison-Ruzzo-Ullman model
