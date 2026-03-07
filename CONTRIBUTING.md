# Contributing to Opine Coding

Thank you for your interest in contributing to the Opine Coding manifesto. We are looking for contributors to help build out our library of **Ecosystem Examples** and refine our methodology for different development environments.

---

## 🏛️ The Contribution Philosophy

We are not just looking for "coding snippets." We are looking for **Architectural Opinions**. 

When contributing a new `.opine` template (e.g., for Rust, React, or Go), follow the **Project Archaeologist** workflow:
1. **Source of Truth:** Don't write rules from scratch. Extract them from established standards (e.g., PEP 8, Airbnb Style Guide, or a robust `.editorconfig`).
2. **Deterministic Focus:** Focus on the rules that prevent "AI Slop"—the specific patterns that LLMs usually get wrong in your chosen stack.
3. **Auditability:** Keep the rules human-readable and tool-agnostic.

---

## 🛠️ How to Contribute

### 1. Propose a New Ecosystem Example
If you want to add a template for a stack not yet covered:
- Create a new folder in `/examples` (e.g., `/examples/rust`).
- Add a `.opine` file that codifies the patterns for that stack.
- Include a `README.md` in that folder explaining the "Why" behind those specific opinions.

### 2. Refine the Methodology
If you have suggestions for the core README or the "Project Archaeologist" prompt:
- Open an Issue first to discuss the change.
- Ensure the suggestion aligns with the goal of **deterministic governance** rather than "tool-specific features."

---

## 🚀 The Pull Request Process

1. **Fork the repo** and create your branch from `main`.
2. **Follow the Scoped Opinions pattern:** Ensure your contribution doesn't clutter the root directory.
3. **Verify the logic:** Test your `.opine` file with at least two different AI agents (e.g., Copilot and Claude) to ensure it effectively governs the output.
4. **Submit the PR:** Link to any relevant issues and provide a brief summary of the architectural philosophy your template enforces.

---

## 📜 Code of Conduct

This project is governed by a simple rule: **Respect the Governance.** We are here to eliminate "Vibe Coding" through professional discipline and clear intent. Keep discussions technical, concise, and focused on improving the relationship between developers and AI.

---

**Next Step:** Check the `/examples` folder to see which stacks are currently missing!
