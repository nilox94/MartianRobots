# MartianRobots
[![CI/CD](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml/badge.svg)](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml)
![Ubuntu badge](https://badgen.net/badge/icon/Ubuntu?icon=terminal&label)
![Windows badge](https://badgen.net/badge/icon/Windows?icon=windows&label)
![macOS badge](https://badgen.net/badge/icon/macOS?icon=apple&label)

## Setup
Clone and run the project by using
```
git clone https://github.com/nilox94/MartianRobots.git
cd MartianRobots
dotnet run --project MartianRobots < Tests/Data/default.in
```

## Problem Statement
The problem statement is located
[here](https://github.com/nilox94/MartianRobots/files/8267078/Technical.skills.-.Developer_EN.002.Backend.NET.docx)
and is formulated as an Input / Output based competitive programming question.

## Architecture
The solution follows the pattern [Entity-Component-System](https://en.wikipedia.org/wiki/Entity_component_system) (ECS),
mainly to split data (stored in Components) from logic (implemented in Systems[s]).
This pattern is handy for simulations (e.g., game engines) and data-oriented programs,
since data are stored in POCOs and can be without their main logic (e.g., during visualization or logging). 

## Testing
The solution is validated via an E2E test,
comparing the result of applying the program to a known set of inputs with the expected set of outputs.

```
FOREACH <known-input>, <known-output> IN <test-suite>
    CHECK program(<known-input>) EQUALS <known-output>
```

The results get published in [a GitHub Actions worlflow](https://github.com/nilox94/MartianRobots/actions/workflows/test-results.yml).
