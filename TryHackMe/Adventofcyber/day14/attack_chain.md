### Advent of Cyber 2023 - Day 14

## Overview

The CTO has manipulated the toy pipeline, causing defects in the toys. McSkidy is countering this by using machine learning to identify and eliminate defective toys.

## Day 14: Machine Learning for Toy Detection

### Incident Overview

The CTO interfered with the toy pipeline, leading to the production of defective toys. McSkidy is implementing machine learning to identify and rectify the issue. The objective is to create a neural network capable of detecting defective toys.

### Learning Objectives

- Understand the basics of machine learning.
- Learn about supervised learning and neural network structures.
- Implement a neural network for detecting defective toys.

### Tasks

1. Access the provided machine.
2. Review the questions in the connection card for Day 14.
3. Start the machine and open the split-screen view for the target.
4. Explore the basics of machine learning and neural networks.
5. Implement the neural network in the provided Python script (detector.py).
6. Train the neural network using the given training dataset.
7. Validate the network's accuracy using the validation dataset.
8. Save the predictions for the testing dataset.

If the neural network achieves more than 90% accuracy, you will receive the flag:

### Zero to Hero on Artificial Intelligence

## Basic Machine Learning Structures

- **Genetic Algorithm:** Mimics natural selection and evolution.
- **Particle Swarm:** Mimics how birds flock and group together.
- **Neural Networks:** Mimics how neurons work in the brain.

## Learning Styles

- **Supervised Learning:** Guide the neural network with known answers.
- **Unsupervised Learning:** Let the neural network identify interesting things.

## Basic Structure of a Neural Network

- Input Layer
- Output Layer
- Hidden Layer(s)

## Feed-Forward Loop

1. Normalize all inputs.
2. Feed inputs to input layer nodes.
3. Propagate data through the network.
4. Read the output from the network.

## Back-Propagation

1. Calculate the difference in received outputs vs. expected outputs.
2. Update the weights of the nodes.
3. Propagate the difference back to other layers.

## Dataset Splits

- Training data (70-80%)
- Validation data (10-15%)
- Testing data (10-15%)

### Putting it All Together
Now that we've covered the basics, we are ready to build our very own neural network. It will show in split screen.
We are provided with the following files:

- `detector.py` - This is the script where we will build our neural network. Some of the sections have already been completed for you.
- `dataset_train.csv` - This is your training dataset.
- `dataest_test.csv` - This is your testing dataset.
 [Detector.py & CSV Files](https://github.com/itsWhiteNight/HackingLab/blob/main/TryHackMe/Adventofcyber/day14/Figures/neural.png)

##[1] Normalizing the Data
		```python
		# Insert Normalization Code Here
		scaler = StandardScaler()
		scaler.fit(train_X)
		train_X = scaler.transform(train_X)
		validate_X = scaler.transform(validate_X)
		test_X = scaler.transform(test_X)
		
##[2] Training the Neural Network
		```python
		# Insert Classifier Code Here
		clf = MLPClassifier(solver='lbfgs', alpha=1e-5, hidden_layer_sizes=(15, 2), max_iter=10000)
		clf.fit(train_X, train_y)


##[3] Validate the Neural Network
		```python
		# Insert Classifier Validation Prediction Code Here
		y_predicted = clf.predict(validate_X)

##[4] Saving the Poisoned Toy Pipeline
		```python
		# Insert Classifier Testing Prediction Code Here
		y_test_predictions = clf.predict(test_X)








