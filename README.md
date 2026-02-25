<img src="src/OpineCoding.Api/wwwroot/favicon.svg" width="48" height="48" align="left"/>

# Opine Coding
### Stop Vibe Coding. Start Governing.

**Opine Coding** is a methodology for professional developers who demand deterministic results from AI agents. 

While "Vibe Coding" relies on an LLM’s probabilistic intuition to bridge gaps in requirements, **Opine Coding** uses an explicit, repository-level "Opinion File" to enforce architectural standards, syntax preferences, and project-specific guardrails.

> [!NOTE]
> **Opine Coding is language- and tool-agnostic.** This repo uses a C# / .NET project as its reference implementation. That is one example of the methodology, not the definition of it. The `.opine` concept works equally well for TypeScript, Python, Go, or any other stack. Wherever your team has a linter, a style guide, or a code review checklist, you have the raw material for an `.opine` file.

---

## Vibe vs. Opine

| Feature | Vibe Coding | Opine Coding |
| :--- | :--- | :--- |
| **Source of Truth** | AI's probabilistic "best guess" | User’s explicit `.opine` file |
| **Consistency** | High variance; changes per prompt | Low variance; follows repo standards |
| **Effort** | Low upfront; high "fix-it" time | High upfront; low "fix-it" time |
| **Outcome** | Generic "Training Data" averages | Deterministic, tailor-made code |
| **Role** | AI as a "Co-pilot" guessing intent | AI as an "Executor" following rules |

---

## The Core Tenets
1. **Context is Not a Suggestion:** The instructions file is the source of truth, overriding the AI's default "best guesses."
2. **Deterministic Output:** If you ask for a service, it should look exactly like your existing services, not a generic snippet.
3. **Intentionality:** You specify the "How" so the AI can focus on the "What."
4. **Governed Execution:** You move from managing prompts to managing a framework.

---

## Implementation Guide

### 0. Auto-Bootstrap (Let the AI Write the First Draft)
Don't start from a blank file. Give your AI agent this prompt and let it act as a project archaeologist — reading your existing enforcement artifacts and translating them into `.opine` opinions:

> Analyse every enforcement artifact in this repository: `.editorconfig`, lint configuration files, formatter configs, build property files, and any existing style guides or rule sets. Based on what you find, generate a `.opine` file that codifies our naming conventions, formatting standards, architectural constraints, and any project-specific no-go patterns. For any section where the artifacts are silent, make no assumption — leave a `# TODO` placeholder instead. Output the result as a single Markdown file, one rule per bullet, grouped by section.

Review the output, cut anything that doesn't reflect a real decision your team has made, and commit it. The AI does the archaeology; you do the editorial review.

### 1. The .opine File
Create a `.opine` file in your repository root. Structure it in named sections so agents can target specific rules.

**Example:**
```markdown
## Naming
- Functions and methods: `camelCase`. Types and classes: `PascalCase`.
- No abbreviations — `userAccountId`, not `usrAcctId`.
- Private fields: `_prefixed`. Constants: `UPPER_SNAKE_CASE`.

## Formatting
- 2-space indent. Spaces, not tabs. LF line endings. Max line length: 120.
- Always insert a trailing newline.

## Error Handling
- Never swallow errors silently — always log or rethrow with added context.
- Prefer typed error results over exceptions for expected failure paths.

## No-Go Zone
- No `console.log` in committed code — use the project logger.
- No hardcoded secrets — use environment variables or a secrets manager.
- No inline SQL — use the query builder or parameterized statements.
```

> **This repo's `.opine`** (in the repository root) is the C# / .NET reference implementation — a complete, real-world example of this structure applied to a specific stack.

### 2. Bootstrap Your AI Agent
Point your AI agent at `.opine` at the start of every session. Each tool has its own instruction file — the content is the same, only the location differs.

| Tool | Instruction File |
| :--- | :--- |
| **GitHub Copilot** | `.github/copilot-instructions.md` |
| **Cursor** | `.cursor/rules/*.mdc` |
| **Windsurf** | `.windsurfrules` |
| **Cline** | `.clinerules` |
| **Aider** | `CONVENTIONS.md` |
| **Continue** | `.continue/config.json` (system prompt field) |

Regardless of tool, the directive is the same:

```markdown
## Session Bootstrap
- Read `.opine` before generating any code. It is the source of truth.
- Apply all sections defined in `.opine`.
- Repo-specific patterns override AI defaults — no exceptions.
```

### 3. Source Your Opinions
Don't write `.opine` rules from scratch — extract them from enforcement artifacts you already own:

| C# | JavaScript / TypeScript | Python | Go | Extracts To |
| :--- | :--- | :--- | :--- | :--- |
| `.editorconfig` | `.eslintrc` / `biome.json` | `pyproject.toml` | `.golangci.yml` | Formatting, naming, lint rules |
| `stylecop.json` | `.prettierrc` | `ruff.toml` | `gofmt` defaults | Style enforcement |
| `Directory.Build.props` | `tsconfig.json` | `setup.cfg` | `go.mod` | Project-level defaults |
| `CodeAnalysis.ruleset` | `eslint-plugin-security` | `bandit` config | `gosec` config | Security rules |

Feed each file to your AI agent and ask it to translate the rules into `.opine` opinions. Review, approve, and commit.

### 4. Keep It Current
Treat `.opine` as a living document. When a language version supersedes a rule, update the opinion. Stale rules are just Vibe Coding by another name.

---

## Adapting to Your Stack

The sections and rules inside `.opine` are entirely yours — name them whatever fits your project. Below are three short examples showing what governed AI output looks like in other ecosystems.

### TypeScript

```markdown
## TypeScript Patterns
- Strict mode always on (`"strict": true` in `tsconfig`). No `any` — use `unknown` and narrow.
- Prefer `type` aliases for object shapes; `interface` only for extensible contracts.
- No default exports — named exports only.
- `readonly` on arrays and object properties where mutation is not intended.

## Naming
- Variables and functions: `camelCase`. Types, enums: `PascalCase`. Constants: `UPPER_SNAKE_CASE`.
- No `I` prefix on interfaces.

## No-Go Zone
- No `as` type assertions — use type guards or `satisfies`.
- No `@ts-ignore` — fix the type, do not suppress it.
- No barrel files (`index.ts` re-exports) — import directly from source.
```

### Python

```markdown
## Python Patterns
- Type annotations on all function signatures — no bare `def foo(x)`.
- `pathlib.Path` over `os.path` for all file system operations.
- `dataclasses` or `pydantic` models for structured data — no plain dicts as public API.

## Naming
- Functions, variables, modules: `snake_case`. Classes: `PascalCase`. Constants: `UPPER_SNAKE_CASE`.
- No single-letter names outside comprehensions and mathematical contexts.

## No-Go Zone
- No bare `except:` — always catch a specific exception type.
- No `print()` in committed code — use `logging`.
- No mutable default arguments — use `None` and guard inside the function body.
```

### Go

```markdown
## Go Patterns
- `context.Context` is always the first parameter of any function crossing a service or I/O boundary.
- Wrap errors with context: `fmt.Errorf("loading user: %w", err)`. Never discard errors.
- Table-driven tests — `[]struct{ name, input, want }` with `t.Run`.

## Naming
- Exported identifiers: `PascalCase`. Unexported: `camelCase`. Acronyms fully uppercase (`HTTP`, `ID`).
- Short receiver names — single letter is idiomatic (`u *User`). No `this` or `self`.

## No-Go Zone
- No `panic` in library code — return errors.
- No `init()` functions — explicit initialization only.
- No `interface{}` / `any` in public API — define a named interface.
```

---

## Community Contributions

Opine Coding is stronger with more stacks represented. If you work in a language or ecosystem not yet covered under `examples/`, the methodology gives you a clear path to contribute.

### The Process

Run the [Auto-Bootstrap prompt](#0-auto-bootstrap-let-the-ai-write-the-first-draft) against your stack's canonical enforcement artifacts. Let the AI extract the first draft. Review it, cut anything not grounded in a real rule, and open a pull request adding it to `examples/{language}/.opine`.

See [CONTRIBUTING.md](CONTRIBUTING.md) for the full Sources of Truth and Proof of Work requirements.

### Examples We'd Welcome

| Ecosystem | Artifacts to Analyse |
| :--- | :--- |
| **Rust** | `clippy.toml`, `rustfmt.toml` |
| **React** | ESLint React plugin, `tsconfig`, component conventions |
| **Vue / Svelte** | ESLint, `vite.config`, component file conventions |
| **Java / Kotlin** | `checkstyle.xml`, `detekt.yml`, `build.gradle` |
| **Ruby** | `.rubocop.yml` |

> [!TIP]
> The best `.opine` submissions come from running the Auto-Bootstrap prompt against a well-maintained open-source project in that language, then filtering the output against the official style guide. The AI does the archaeology; you validate the findings.
