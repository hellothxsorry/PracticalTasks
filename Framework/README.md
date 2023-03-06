# Practical Task 12
"Framework" module:

**Develop an automation framework for the Hardcore task in WebDriver.
Hardcore task:**
- When completing the task, you must use the capabilities of Selenium WebDriver, the unit test of the framework, and the concept of Page Object. Automate the following   script:
1. Open https://cloud.google.com/
2. By clicking the search portal button at the top of the page, enter in the search field "Google Cloud Platform Pricing Calculator".
3. Start a search by clicking the search button.
4. In the search results, click "Google Cloud Platform Pricing Calculator" and go to the calculator page.
5. Activate the COMPUTE ENGINE section at the top of the page
6. Fill out the form with the following data:
   * Number of instances: 4
   * What are these instances for?: leave blank
   * Operating System / Software: Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS
   * VM Class: Regular
   * Instance type: n1-standard-8    (vCPUs: 8, RAM: 30 GB)
   * Select Add GPUs
     * Number of GPUs: 1
     * GPU type: NVIDIA Tesla V100
   * Local SSD: 2x375 Gb
   * Datacenter location: Frankfurt (europe-west3)
   * Commited usage: 1 Year
7. Click Add to Estimate
8. Select option EMAIL ESTIMATE
9. In a new browser tab, open https://yopmail.com/ or similar service to generate temporary email
10. Copy the email address generated by yopmail.com
11. Return to the calculator, in the Email field enter the address from the previous paragraph
12. Click SEND EMAIL
13. Wait for the letter with the calculation of the cost and check that the Total Estimated Monthly Cost in the letter matches what is displayed in the calculator
---
**The final framework should include the following:**
1. A WebDriver manager for managing browser connectors
2. Page Object/Page Factory for page abstractions
3. Models for business objects of the required elements
4. Property files with test data for at least two different environments
5. XML suites for smoke tests and other tests
6. If the test fails, a screenshot with the date and time is taken.
7. The framework should include an option for running with Jenkins and browser parameterization, test suite, environment.
8. Test results should be displayed on the job chart, and the screenshots should be archived as artifacts.
---
<p align="center">
  <img src="https://user-images.githubusercontent.com/50228202/217504592-940f88ec-a6a6-4c7e-be01-39bf57e75d25.png">
</p>

<p align="center">
  <img src="https://user-images.githubusercontent.com/50228202/217504720-73c00fbd-271c-4a5c-b9f1-8cc02379147c.png">
</p>

<p align="center">
  <img src="https://user-images.githubusercontent.com/50228202/217524241-126aa4d2-69cf-4c64-ae83-e931febd4b6d.png">
</p>