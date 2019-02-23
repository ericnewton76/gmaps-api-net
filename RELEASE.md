## Release
- Bump up version number in package.json/appveyor.yml
- Commit the version change with the following message: chore(release): [version number]
- tag `git tag [version number]` maybe after listing tags with `git tag`
- push changes and a tag (git push --tags)
- [future] switch to the gh-pages branch: git checkout gh-pages
- [future] copy content of the dist folder to the main folder
- [future] Commit the version change with the following message: chore(release): [version number]
- [future] push changes
- [future] switch back to the main branch
- modify package.json/appveyor.yml to bump up version for the next iteration
- commit (chore(release): starting [version number]) and push
- publish Bower and NuGet packages

bash commands:
```bash
export BUILD_VERSION={{major}}.{{minor}}
sed -i '1s/.*/version: $BUILD_VERSION\.{build}/' appveyor.yml
git tag $BUILD_VERSION.0
git add appveyor.yml && git commit -m "chore(release): $BUILD_VERSION.0"
git push 
git push --tags
```
