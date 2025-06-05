name: Feature Request
description: Suggest an idea or enhancement for beagl
title: "[Feature]: "
labels: ["enhancement"]
assignees: []
body:
  - type: markdown
    attributes:
      value: |
        Thank you for suggesting an idea to improve beagl!
  - type: textarea
    id: summary
    attributes:
      label: Feature summary
      description: A clear and concise description of the feature or enhancement.
    validations:
      required: true
  - type: textarea
    id: motivation
    attributes:
      label: Motivation
      description: Why is this feature important? What problem does it solve?
    validations:
      required: true
  - type: textarea
    id: solution
    attributes:
      label: Proposed solution
      description: How would you like to see this implemented?
    validations:
      required: false
  - type: textarea
    id: alternatives
    attributes:
      label: Alternatives considered
      description: Did you consider any alternative solutions or features?
    validations:
      required: false
  - type: textarea
    id: additional
    attributes:
      label: Additional context
      description: Add any other context, mockups, or screenshots about the feature request here.
