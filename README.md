# Opine Coding
### Stop Vibe Coding. Start Governing.

**Opine Coding** is a methodology for professional developers who demand deterministic results from AI agents. It is the architectural opposite of "Vibe Coding."

> [!IMPORTANT]
> **This is a Manifesto, not a Product.**
> The code provided in this repository is a **sample reference implementation** using C# and .NET. It exists to demonstrate the *idea* in practice. You are encouraged to take the core concept—governing AI through explicit repo-level opinions—and build your own implementation using whatever language, structure, or tooling fits your stack.

---

## 🧭 The Core Concept

In **Vibe Coding**, you rely on the AI's probabilistic "best guess." This leads to "AI Code Slop"—technically functional code that violates your team's architecture, naming standards, and professional patterns.

**Opine Coding** establishes the developer as the **Governor**. You provide the AI with a point of view (an Opinion) before it writes a single line of code. By using the AI as a **Project Archaeologist** to extract rules from your existing environment, you create a "Source of Truth" that enforces consistency across your entire team.

### Vibe vs. Opine

| Feature | Vibe Coding | Opine Coding |
| :--- | :--- | :--- |
| **Source of Truth** | AI's probabilistic "best guess" | User’s explicit `.opine` file |
| **Consistency** | High variance; "training data" averages | High consistency; follows repo standards |
| **Effort** | Low upfront; high "fix-it" rework | High upfront; deterministic execution |
| **Scale** | Fragmented; "Shaky" code across teams | Unified; a single professional voice |
| **Technical Debt** | High (Boilerplate bloat, style drift) | Low (Architectural guardrails) |

---

## 📜 The Core Tenets

1. **Context is Not a Suggestion:** The instructions file is the source of truth, overriding the AI's default "best guesses."
2. **Deterministic Output:** If you ask for a service, it should look exactly like your existing services, not a generic snippet.
3. **Intentionality:** You specify the *How* so the AI can focus on the *What*.
4. **Governed Execution:** You move from managing individual prompts to managing a framework of intent.

---

## 🛠️ Implementation Guide

### 0. The Project Archaeologist (Auto-Bootstrap)
Don't write your rules from scratch. Use the AI to discover them. Run this prompt first in your own project:

> *"Analyze my `.editorconfig`, `lint` rules, and project dependencies. As a **Project Archaeologist**, generate a `.opine` file that codifies our naming conventions, architectural constraints, and formatting standards. Focus on making future output consistent with this specific environment."*

### 1. The .opine File
Place a `.opine` (or `.instructions.md`) file in your repository root. Structure it in named sections so agents can target specific rules. 

**Example Structure:**
```markdown
## Naming
- Functions/Methods: `camelCase`. Types/Classes: `PascalCase`.
- Private fields: `_prefixed`. Constants: `UPPER_SNAKE_CASE`.

## Error Handling
- Never swallow errors silently.
- Prefer typed error results over exceptions for expected failure paths.

## No-Go Zone
- No `console.log` or `print` in committed code.
- No hardcoded secrets; use environment variables.
```

### 2. Anchor Your Tools
Point your agent at the `.opine` file. This prevents "Rule Drift" when switching between different IDEs or CLI agents.

| Agent | Target File | Integration Method |
| :--- | :--- | :--- |
| **Claude Code** | `CLAUDE.md` | Map your `.opine` content here. |
| **Cursor** | `.cursor/rules/` | Use `.opine` as the global source for `.mdc` files. |
| **Windsurf** | `.windsurfrules` | Use the "Global Context" feature. |
| **GitHub Copilot** | `.github/copilot-instructions.md` | Paste or reference the `.opine` content. |

---

## 🌎 Ecosystem Examples

The `.opine` concept works across any stack. Below is what "Governed AI" looks like in other ecosystems.

### TypeScript
```markdown
## TypeScript Patterns
- Strict mode always on. No `any` — use `unknown` and narrow.
- Prefer `type` aliases for object shapes; named exports only.
- No `as` type assertions — use type guards or `satisfies`.
```

### Python
```markdown
## Python Patterns
- Type annotations on all function signatures.
- `pathlib.Path` over `os.path` for all file system operations.
- No bare `except:` — always catch a specific exception type.
```

### Go
```markdown
## Go Patterns
- `context.Context` is always the first parameter in I/O boundaries.
- Wrap errors with context: `fmt.Errorf("loading user: %w", err)`.
- No `panic` in library code — return errors.
```

---

## 🏛️ Enterprise & Team Scaling

### Consistency Over Determinism
While LLMs are probabilistic, Opine Coding narrows that probability to a professional window. It ensures that a PR written by an AI in one office looks identical to a PR written by a dev across the globe.

### Scoped Opinions (No Context Pollution)
For large monorepos, avoid one massive file. Use **Scoped Opinions**:
* `root/.opine` -> Global architectural and security rules.
* `src/api/.opine` -> Language-specific patterns.
* `src/web/.opine` -> Frontend-specific patterns.

AI agents are path-aware and will prioritize the opinions closest to the file they are editing.

### Reducing AI Tech Debt
Treat your `.opine` file as a pre-emptive Code Review. If you find yourself correcting the same AI mistake multiple times, that correction belongs in your Opinions. This prevents "AI Code Slop" from accumulating in your codebase.

---

## 🤝 Community Contributions

Opine Coding is a language-agnostic movement. Since this repo is a reference implementation, we welcome templates for other stacks to help build the library of opinions.

* **Reference Implementation:** C# / .NET (found in `/src`)
* **Community Targets:** React, Rust, Go, Python (Pydantic). 
* See [CONTRIBUTING.md](CONTRIBUTING.md) for pull request details.
