# MartianRobots
[![CI/CD](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml/badge.svg)](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml)
![macOS badge](https://badgen.net/badge/icon/macOS?icon=apple&label)
![Windows badge](https://badgen.net/badge/icon/Windows?icon=windows&label)

## Problem Statement
The problem statement can be found [here](https://github.com/nilox94/MartianRobots/files/8267078/Technical.skills.-.Developer_EN.002.Backend.NET.docx)
and is formulated as an Input / Output based competitive programming question.

## Architecture
The solution splits data (stored in states) from logic (implemented in behaviors).

## Testing
The solution validation is done via an E2E test that compares the result of applying the program to a known set of inputs with the expected set of outputs.

```
FOREACH <known-input>, <known-output> IN <test-suite>
    CHECK program(<known-input>) EQUALS <known-output>
```

The results are published in [a GitHub Actions worlflow](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml).