# Simulated Alarm System

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/your-repo)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

## Overview
The Simulated Alarm System consists of:
- A **backend service** built with ASP.NET Core.
- A **frontend application** developed using Angular.

The system reads alarm configurations from XML files, triggers alarms based on predefined rules, and provides a customizable list view to display alarms.

---

## Table of Contents
1. [Features](#features)
2. [Prerequisites](#prerequisites)
3. [Setup Instructions](#setup-instructions)
4. [Configuration](#configuration)
5. [API Endpoints](#api-endpoints)
6. [Design Choices](#design-choices)
7. [Troubleshooting](#troubleshooting)
8. [License](#license)

---

## Features
- **User Authentication**: Registration and login.
- **Alarm Management**: XML-based configuration and real-time data push.
- **Customizable UI**: Angular list view for alarms with drag-and-drop column customization.
- **Secure Communication**: JSON-based API and CORS-enabled backend.

---

## Prerequisites

### Backend
- .NET 7 SDK or higher
- Visual Studio or any preferred IDE

### Frontend
- Node.js (v14 or higher)
- Angular CLI (`npm install -g @angular/cli`)

---

## Setup Instructions

### Backend (ASP.NET Core)
1. Navigate to the `Backend` directory:
   ```bash
   cd Backend