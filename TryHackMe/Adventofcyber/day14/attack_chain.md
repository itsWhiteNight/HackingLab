### Advent of Cyber 2023 - Day 14

### Task 1: Introduction

Welcome to Day 14 of Advent of Cyber 2023! In this task, we delve into the world of Machine Learning (ML) and its application in solving a festive challenge. The CTO has introduced an interesting twist in the toy-making process, and we need to leverage ML to detect defective toys. Let's get started!

### Learning Objectives

- Understand what machine learning is.
- Learn basic machine learning structures and algorithms.
- Use neural networks to predict defective toys.

### Accessing the Machine

Make sure to start the Target Machine as instructed. The split-screen view will be available for the target.

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

## Creating the Datasets

```python
# Insert Dataset Split Code Here
train_X, validate_X, train_y, validate_y = train_test_split(X, y, test_size=0.2)

