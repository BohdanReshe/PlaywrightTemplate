# Locator Strategy Guide (Playwright .NET)

## Preferred (stable)
- data-testid / data-qa
- ARIA roles: GetByRole()
- Labels: GetByLabel()

## Acceptable
- Semantic CSS (stable classes)
- Visible text: GetByText() (careful: i18n/content changes)

## Avoid
- XPath
- nth-child / deep DOM selectors

## Rule
Locators live in Pages/Components only. Steps must call page methods.