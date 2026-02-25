# Contributing to Opine Coding

This repo is a methodology manifesto. The most valuable contributions are ones that sharpen the idea with evidence — not opinions from memory, but opinions extracted from the artifacts that already govern a real codebase.

---

## The Archaeology Workflow

Before writing a single rule by hand, run the Auto-Bootstrap prompt from the README against your target stack's enforcement artifacts. Let the AI do the extraction; you do the editorial review.

Paste this prompt into your AI agent of choice:

> Analyse every enforcement artifact in this repository: `.editorconfig`, lint configuration files, formatter configs, build property files, and any existing style guides or rule sets. Based on what you find, generate a `.opine` file that codifies our naming conventions, formatting standards, architectural constraints, and any project-specific no-go patterns. For any section where the artifacts are silent, make no assumption — leave a `# TODO` placeholder instead. Output the result as a single Markdown file, one rule per bullet, grouped by section.

Review the output, remove any rule that doesn't reflect a real team decision, and commit. Manually authored rules are permitted but must clear the same bar: traceable to a real enforcement artifact.

---

## Add a Language Example

New language examples live under `examples/{language}/.opine` and demonstrate the methodology applied to a real-world stack.

1. Run the Archaeology Workflow against your stack's canonical enforcement artifacts.
2. Create `examples/{language}/.opine` modelled on the existing examples.
3. Use standard section headings: `Architecture`, `Naming`, `Formatting`, `Patterns`, `Async`, `No-Go Zone`.
4. Document your Sources of Truth in the pull request body (see below).
5. Include a Proof of Work (see below).

---

## Propose or Update an Opinion

1. Open an issue describing the rule you want to add, change, or remove.
2. Explain what ambiguity the rule eliminates or what failure mode it prevents.
3. Submit a pull request against the relevant `.opine` file.
4. Document Sources of Truth and Proof of Work in the PR body.

---

## Sources of Truth

Every rule must be traceable to a real enforcement artifact. In your pull request body, list what you analysed:

```
Sources
- Airbnb JavaScript Style Guide via .eslintrc (naming, no-go patterns)
- Prettier defaults via .prettierrc (formatting)
- TypeScript strict mode via tsconfig.json (patterns)
```

Rules without a traceable source are opinions without basis. They will not be merged.

---

## Proof of Work

Pull requests that add or change rules must include a Proof of Work: a before-and-after showing that the rule produces a measurable difference in AI output.

In your pull request body, document it like this:

```
Proof of Work — No default exports (TypeScript)

Prompt: "Create a utility function that formats a date."

Vibe output (no .opine):
  export default function formatDate(date: Date): string { ... }

Opine output (.opine rule: "No default exports — named exports only"):
  export function formatDate(date: Date): string { ... }
```

A rule that produces no observable output difference does not belong in an `.opine` file.

---

## Style Guide

- Rules are imperative: "Use X", "No bare Z", "Always prefix with P".
- One idea per bullet. If you cannot state the rule in one line, it is two rules.
- No rules without a Source of Truth.
- No `# TODO` placeholders in submitted rules — archaeology incomplete means PR not ready.

---

## Pull Request Checklist

- [ ] Archaeology Workflow used — AI extracted the first draft from existing artifacts.
- [ ] Sources of Truth listed in the PR body.
- [ ] Proof of Work included — Vibe vs. Opine output diff is visible.
- [ ] Rules are imperative, one idea per bullet, no `# TODO` remaining.
- [ ] Line endings match the file type (LF for `.md`; see `.editorconfig`).
- [ ] The C# project builds and tests pass (`dotnet test src/`).
