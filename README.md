# Opine Coding
### Stop Vibe Coding. Start Governing.

**Opine Coding** is a methodology for professional developers who demand deterministic results from AI agents. 

While "Vibe Coding" relies on an LLM’s probabilistic intuition to bridge gaps in requirements, **Opine Coding** uses an explicit, repository-level "Opinion File" to enforce architectural standards, syntax preferences, and project-specific guardrails.

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

### 1. The .opine File
Create a `.opine` file in your repository root. Structure it in named sections so agents can target specific rules.

**Example:**
```markdown
## C# Patterns
- Use Primary Constructors. Favor `records` for DTOs.
- Use collection expressions (`[]`) for all empty and initialized collections.
- `readonly` on all eligible fields.

## Naming
- Private instance fields: `_camelCase`. No `m_` prefix.
- Types, methods, properties: `PascalCase`. Interfaces: prefix `I`.

## Async
- `ValueTask.FromResult` for synchronous interface implementations.
- Forward `CancellationToken` where applicable.

## No-Go Zone
- No generic `try-catch` — use Global Exception Middleware.
- No `#region` directives. No `var`.
```

### 2. Bootstrap Your AI Agent
Point your AI agent at `.opine` at the start of every session. In GitHub Copilot, use `.github/copilot-instructions.md`:

```markdown
## Session Bootstrap
- Read `.opine` before generating any code. It is the source of truth.
- Apply all sections: Architecture, C# Patterns, Naming, Formatting, Usings, Async, Security, No-Go Zone.
- Repo-specific patterns override AI defaults — no exceptions.
```

### 3. Source Your Opinions
Don't write `.opine` rules from scratch — extract them from enforcement artifacts you already own:

| Source | Extracts To |
| :--- | :--- |
| `.editorconfig` | Formatting, Naming, C# sugar preferences |
| `stylecop.json` | Ordering rules, tuple naming |
| `CodeAnalysis.ruleset` | Security, structural rules, diagnostic severities |
| `Directory.Build.props` | Nullable, warnings-as-errors, target framework |

Feed each file to your AI agent and ask it to translate the rules into `.opine` opinions. Review, approve, and commit.

### 4. Keep It Current
Treat `.opine` as a living document. When a language version supersedes a rule (e.g., `Array.Empty<T>()` → `[]`), update the opinion. Stale rules are just Vibe Coding by another name.