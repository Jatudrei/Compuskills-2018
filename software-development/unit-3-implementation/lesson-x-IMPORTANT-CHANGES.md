**IMPORTANT** - shita needs to be to show demos of the actual security bugs and how to fix them w/ these principals

-ui leaks
  - urls!
  - same id number as internal

  - potential problems
    - hidden fields - exosing information
    - user.identity.claims - encrypted
    - easy to dump all hidden field values w/ jquery
    - URL direct account number exposure
  - injection via comments, reviews, etc
  - HTML encoding(and general encoding)
   - don't use mvchtmlstring or html.raw
- cors
- CSRF - via direct links and via injection

OWASP

- antiforgery token in mvc
- plain text passwords / hashing

- mitigate and remediate