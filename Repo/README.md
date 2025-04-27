# Design Detailed Document Group 14

## Table of Contents
1. [Cover]
2. [Introduction]
3. [Description]
4. [Problems]
5. [Conclusions]

---

## Cover
- **Group ID**: 14
- **Document Title**: Design Detailed Document Group 14

---

## Introduction
- **Group Members**:
  - Alfonso Lozano
  - Jaime Felices
  - Miguel Velasco
  
- **Summary**:
  - This document serves as a detailed design report for the Air UFV Simulation System, a console-based application that simulates the operation of an airport, including aircraft management, runway allocation, and fuel consumption tracking. The project is implemented in C# and follows an object-oriented design approach.

---

## Description
- The simulator is a tick-based system designed to manage and simulate the operations of aircraft approaching and landing at an airport. Each tick represents a 15-minute interval, during which the system updates critical parameters and transitions aircraft through various operational states. The solution is implemented using an object-oriented approach, ensuring modularity and scalability.
  
![classdiagram](https://github.com/user-attachments/assets/616ab7d5-c4c2-47cd-a26d-9a062ddad2c8)


---

## Problems
- **Challenges Faced**:
  - **Adding One More Runway After Significant Progress**: During the development process, we realized the need to add an additional runway to handle increased traffic. This required significant change of the code to integrate the new runway, which introduced additional time.
  - **Implementing the CSV File**: Integrating the CSV file for data posed more time than expected. fixing the data flow between the CSV file and the system required additional effort to ensure 0 errors.
  - **Free Runway and Release Runway Issue**: We encountered a issue where the logic for freeing a runway and releasing it for the next airplane was flawed because a misplaced else if statement. This caused the system to incorrectly release a runway while simultaneously altering the status of a different airplane.

---

## Conclusions
- **Lessons Learned**:
  - The project emphasized the importance of effective communication and teamwork while coding. Each member contributed unique perspectives and skills.
  - We learned to adapt to unexpected changes like adding new features or fixing errors, which will help to solve problems faster in new projects.
- **Future Projects**:
  - This experience provided valuable insights into areas for improvement, such as better initial planning and anticipating potential challenges earlier in the development process.
