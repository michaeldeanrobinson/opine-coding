# Contributing to Opine Coding

Thank you for your interest in contributing. This repo is a methodology manifesto — contributions that sharpen the idea, improve the examples, or extend it to new stacks are the most valuable.

## How to Contribute

### Propose a New Opinion

1. Open an issue describing the opinion you want to add or change.
2. Cite the authoritative source (a linter rule, an official style guide, a widely-adopted community convention).
3. Explain what problem the opinion solves or what ambiguity it eliminates.
4. If accepted, submit a pull request updating the relevant `.opine` file.

### Update an Existing Example

1. Open an issue or a pull request against the relevant file under `examples/`.
2. Ground the change in an authoritative source.
3. Keep rules concise — one idea per bullet, starting with an action verb.

### Add a New Language Example

1. Create `examples/{language}/.opine`.
2. Model the structure after existing examples — sections match standard `.opine` headings (Architecture, Naming, Formatting, Patterns, Async, No-Go Zone).
3. Source every rule from a real enforcement artifact (linter config, official style guide, or formatter defaults).
4. Submit a pull request with a brief description of the sources used.

## Style Guide

- Keep rules short and imperative: "Use X over Y", "No bare Z".
- One idea per bullet.
- No rules without a traceable source — an opinion without basis is just a preference.

## Pull Request Checklist

- [ ] Rules are sourced from real enforcement artifacts.
- [ ] No spelling errors.
- [ ] Line endings match the file type (LF for `.md`; check `.editorconfig`).
- [ ] The C# project builds and tests pass (`dotnet test src/`).
