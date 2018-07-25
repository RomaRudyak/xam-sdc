# SDC Coach

This project main goal is to provide easy way for Coaches to check presents of students in Social Dance Club.

## Project metrics

|Name|Statistics|
|---|---|
|Build|[![Build Status](https://app.bitrise.io/app/34e86a7014b059a5/status.svg?token=Gbpg3Yl4XDgUO6x_kwJ4PA&branch=master)](https://app.bitrise.io/app/34e86a7014b059a5)|
|Metric|![metric](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=ncloc)|
||![metric](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=coverage)|
||![duplicated_lines_density](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=duplicated_lines_density)|
|Quality|![alert_status](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=alert_status)|
||![sqale_rating](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=sqale_rating)|
||![security_rating](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=security_rating)|
||![code_smells](https://sonarcloud.io/api/project_badges/measure?project=SDC-Coach&metric=code_smells)|

## Pre-requirments

Foolow this steps befor firs compilaion:

1. Create your [Google Firebase Console Platform](https://github.com/CrossGeeks/GoogleClientPlugin/blob/master/GoogleClient/docs/GoogleFirebaseConsoleSetup.md) application.
2. Create `secrets.json` file in `SDC.Coach` folder
3. Add next content for the file:
    ```json
    {
        "GoogleClientIdiOS": "[iOS ClientId]",
        "GoogleClientIdDroid": "[Android ClientId]"
    }
    ```