# Silverness.SharedKernel

[![NuGet Version](https://img.shields.io/nuget/v/Silverness.SharedKernel.svg)](https://www.nuget.org/packages/Silverness.SharedKernel/)
[![Build Status](https://img.shields.io/github/actions/workflow/status/Silverness/SharedKernel/build-and-publish.yml?branch=main)](https://github.com/Silverness/SharedKernel/actions)

## Installation

```bash
dotnet add package Silverness.SharedKernel
```

## Versioning Strategy

This library uses **GitVersion** with **GitHub Flow** for semantic versioning:

### Branch-Based Versioning

| Branch Type | Version Pattern | Example | Purpose |
|-------------|----------------|---------|---------|
| `main` | `{Major}.{Minor}.{Patch}` | `1.2.3` | Stable releases |
| `feature/*` | `{Base}-{BranchName}.{Commits}` | `1.2.3-add-logging.5` | Feature development |
| `pull-request` | `{Base}-PullRequest.{Number}.{Commits}` | `1.2.3-PullRequest.42.2` | PR validation |
| Tagged | Tag version | `2.0.0`, `2.1.0-beta.1` | Official releases |

### Semantic Versioning Control

Use commit message prefixes to control version increments:

- **Major**: `+semver:major` or `+semver:breaking`
- **Minor**: `+semver:minor` or `+semver:feature`  
- **Patch**: `+semver:patch` or `+semver:fix`
- **No bump**: `+semver:none` or `+semver:skip`

```bash
git commit -m "feat: add new entity base class +semver:minor"
git commit -m "fix: resolve domain event ordering +semver:patch"
git commit -m "BREAKING: remove deprecated interfaces +semver:major"
```

## Branching Strategy (GitHub Flow)

### Development Workflow

1. **Feature Development**

   ```bash
   git checkout -b feature/new-feature
   # Make changes
   git push origin feature/new-feature
   # Create Pull Request to main
   ```

2. **Pull Request Process**
   - Automated validation runs tests and builds
   - Version preview generated (e.g., `1.2.3-PullRequest.42.1`)
   - Code review and approval required
   - Merge to `main` triggers release build

3. **Release Process**

   ```bash
   # Create and push tag for release
   git tag v1.2.0
   git push origin v1.2.0
   
   # GitHub Actions automatically:
   # - Builds package with tag version
   # - Publishes to GitHub Packages
   # - Creates GitHub Release
   ```

### Automated Release Pipeline

| Trigger | Action | Package Published |
|---------|--------|-------------------|
| Pull Request | Validate only | None |
| Push to `main` | Build + test + version | GitHub Packages (dev) |
| Tag push (`v*.*.*`) | Build + test + release | GitHub Packages + NuGet.org |
| Tag push (`v*.*.*-*`) | Build + test + prerelease | GitHub Packages + NuGet.org |

## Release Types

### Development Releases

- **Trigger**: Every push to `main`
- **Version**: Auto-incremented patch (e.g., `1.2.4`)
- **Distribution**: GitHub Packages only
- **Purpose**: Continuous integration testing

### Production Releases

- **Trigger**: Git tags matching `v*.*.*`
- **Version**: Exact tag version (e.g., `v2.1.0` → `2.1.0`)
- **Distribution**: GitHub Packages + NuGet.org
- **Purpose**: Official stable releases

### Prerelease Versions

- **Trigger**: Git tags with suffix (e.g., `v2.0.0-beta.1`)
- **Version**: Tag version with prerelease suffix
- **Distribution**: GitHub Packages + NuGet.org
- **Purpose**: Beta testing, release candidates

## Package Distribution

### GitHub Packages (Private)

- All builds from `main` branch
- All tagged releases
- Access requires GitHub authentication

## Local Development

```bash
# Clone and build
git clone https://github.com/Silverness/SharedKernel.git
cd SharedKernel
dotnet restore
dotnet build

# Run tests
dotnet test

# Create local package
dotnet pack --configuration Release
```

## Version History

- **v0.1.x**: Initial development versions
- **v1.0.0**: First stable release (planned)

## License

MIT License - see [LICENSE](LICENSE) file for details.

---

**Issues**: [GitHub Issues](https://github.com/Silverness/SharedKernel/issues)
