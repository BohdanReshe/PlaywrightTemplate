# Playwright .NET BDD Template (NUnit + ReqnRoll)

Scalable UI automation template built with:

-   Playwright (.NET)\
-   ReqnRoll (BDD / Gherkin)\
-   NUnit\
-   Page Object Model + Components\
-   Trace & Screenshot artifacts on failure\
-   Scenario-level retries\
-   Action-level retries\
-   CI-ready runsettings (PR / CI separation)

------------------------------------------------------------------------

## Architecture Overview

### Solution Structure

    PlaywrightTemplate/
    ├── src/
    │   ├── Framework/
    │   │   ├── Config/
    │   │   ├── Driver/
    │   │   ├── Pages/
    │   │   ├── Components/
    │   │   ├── Reporting/
    │   │   └── Utilities/
    │   └── Tests/
    │       ├── Hooks/
    │       ├── Features/
    │       ├── StepDefinitions/
    │       └── Support/
    ├── runsettings/
    │   ├── pr.runsettings
    │   └── ci.runsettings

### Design Principles

-   Framework layer does not depend on NUnit or ReqnRoll.
-   Test layer handles test-runner integrations.
-   All locators live inside Page Objects.
-   Step definitions call page methods only.
-   Retries are handled at:
    -   Scenario level (ReqnRoll plugin)
    -   Action level (custom Retry utility)
-   Artifacts are generated only on failure.

------------------------------------------------------------------------

## Demo Applications

-   https://www.saucedemo.com\
-   https://the-internet.herokuapp.com

CI runsettings supports preview environments via `#{}#` token in base
URLs.

------------------------------------------------------------------------

## Prerequisites

-   .NET SDK 8+\
-   macOS / Linux / Windows

------------------------------------------------------------------------

## Install Playwright Browsers

After first build:

``` bash
dotnet build src/Tests/Tests.csproj
playwright install
```

If `playwright` command is not found:

``` bash
dotnet tool install --global Microsoft.Playwright.CLI
export PATH="$PATH:$HOME/.dotnet/tools"
```

------------------------------------------------------------------------

## Running Tests

### PR configuration

``` bash
dotnet test src/Tests/Tests.csproj --settings runsettings/pr.runsettings
```

### CI configuration

``` bash
dotnet test src/Tests/Tests.csproj --settings runsettings/ci.runsettings
```

------------------------------------------------------------------------

## Run With Visible Browser

``` bash
HEADLESS=false SLOWMO_MS=200 dotnet test src/Tests/Tests.csproj --settings runsettings/pr.runsettings
```

------------------------------------------------------------------------

## Retries

Retries are configured at two levels.

### Scenario-level retry

Configured via:

-   `reqnroll.json`
-   `databinding.Reqnroll.NUnit.Retry`

### Action-level retry

Controlled via `RETRIES` parameter in runsettings.

------------------------------------------------------------------------

## Locator Strategy

### Preferred

-   `data-testid` / `data-qa`
-   `GetByRole(...)`
-   `GetByLabel(...)`

### Acceptable

-   Stable semantic CSS selectors

### Avoid

-   XPath
-   `nth-child` selectors
-   Deep DOM structure selectors

All locator decisions are centralized inside Page Objects.

------------------------------------------------------------------------

## Artifacts

On failure the framework generates:

-   Full-page screenshot\
-   Playwright trace (`trace.zip`)

Artifacts are stored under:

    TestResults/artifacts/

------------------------------------------------------------------------

## Tags

Examples:

-   `@smoke`
-   `@regression`
-   `@saucedemo`
-   `@herokuapp`

Run specific tag:

``` bash
dotnet test --filter "TestCategory=smoke"
```

------------------------------------------------------------------------

## Purpose

This repository demonstrates:

-   Clean automation architecture
-   Proper separation of concerns
-   CI-ready configuration
-   BDD implementation with scalable structure
-   Production-style framework design

------------------------------------------------------------------------

## Author

Bohdan Reshetilov
QA Automation Engineer / SDET
