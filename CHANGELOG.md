# Changelog

## 0.7.0 (2026-01-23)

Full Changelog: [v0.6.0...v0.7.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.6.0...v0.7.0)

### Features

* **client:** add `ToString` to `ApiEnum` ([ae941c8](https://github.com/cjavdev/spotted-dotnet/commit/ae941c8f923d1a28201f7a3230823164a2b967ae))
* **client:** add Equals and ToString to params ([2c968f6](https://github.com/cjavdev/spotted-dotnet/commit/2c968f684d9879e0e1f152281c44f6da19e4fe0f))


### Bug Fixes

* **ci:** don't throw an error about missing lsof ([02165cc](https://github.com/cjavdev/spotted-dotnet/commit/02165cc783a2c646a6761de13d4a8f0562b60bd4))


### Chores

* **internal:** add copy constructor tests ([7013602](https://github.com/cjavdev/spotted-dotnet/commit/7013602a5e3f94e832e8b04af093af575deed115))
* **internal:** simplify imports ([aa26cc4](https://github.com/cjavdev/spotted-dotnet/commit/aa26cc4f9947c2e4fb6f54bdde26d07d5db30354))
* **internal:** update `actions/checkout` version ([8118778](https://github.com/cjavdev/spotted-dotnet/commit/811877858b4082db8468c2c6cbf8b75a9d85a85b))

## 0.6.0 (2026-01-15)

Full Changelog: [v0.5.0...v0.6.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.5.0...v0.6.0)

### ⚠ BREAKING CHANGES

* **client:** change casing of some identifiers
* **client:** **Migration:** Only use all-caps in PascalCase for two-letter acronyms. Otherwise, use a capital letter for the first letter and lowercase letters for the rest.
* **client:** add pagination

### Features

* **api:** manual updates ([5413eb1](https://github.com/cjavdev/spotted-dotnet/commit/5413eb1019560d5396328c71b21e7bfd1755d76a))
* **api:** manual updates ([a9afbf4](https://github.com/cjavdev/spotted-dotnet/commit/a9afbf4fa05a35b4743b7cfdb8ab03fd21252ae7))
* **api:** manual updates ([e103ed6](https://github.com/cjavdev/spotted-dotnet/commit/e103ed683a593ad054f7440e0703a1bf26f3a0fd))
* **api:** manual updates ([d146c8d](https://github.com/cjavdev/spotted-dotnet/commit/d146c8d1082ca36a7ca6d7eeba4209c3362496ba))
* **api:** turn off oauth ([d5fd3cd](https://github.com/cjavdev/spotted-dotnet/commit/d5fd3cd18f9ce182edd5540db5a738091ca2927e))
* **client:** add helper functions for raw messages ([a7c7651](https://github.com/cjavdev/spotted-dotnet/commit/a7c76513fbd54f4af05fb632fb3ae6115e266a79))
* **client:** add more `ToString` implementations ([834cf2c](https://github.com/cjavdev/spotted-dotnet/commit/834cf2c8b4e4d7d8f892f7082b537c0f2afe98b5))
* **client:** add pagination ([3ff02eb](https://github.com/cjavdev/spotted-dotnet/commit/3ff02eb08a64a7f149544712d493afba581d8984))
* **client:** support accessing raw responses ([b65d061](https://github.com/cjavdev/spotted-dotnet/commit/b65d0614af3e7770743bbff7b9e3a7bfe4a6f65b))


### Bug Fixes

* **ci:** run tests properly on windows ([d338698](https://github.com/cjavdev/spotted-dotnet/commit/d338698b7eaccfae814a4d828d69c6a26ee5c62c))
* **client:** add missing serializer options ([8dbcfe0](https://github.com/cjavdev/spotted-dotnet/commit/8dbcfe02a89d7ed02eb593f655f5c8496c4bdb28))
* **client:** bad deserialize call for void method ([43e731c](https://github.com/cjavdev/spotted-dotnet/commit/43e731cf66b9d701e5ec37aea7ed171c0070923d))
* **client:** copy path params in params copy constructors ([f4af49a](https://github.com/cjavdev/spotted-dotnet/commit/f4af49afe2fc0015ec0f43e23c126fb07f34d8ac))
* **client:** don't dispose `HttpResponse` for methods that directly return it ([9d6e6da](https://github.com/cjavdev/spotted-dotnet/commit/9d6e6da67fb3407e682744db533e5d0f22a1f4b5))
* **client:** ensure deep immutability for deep array/dict structures ([2bfffa1](https://github.com/cjavdev/spotted-dotnet/commit/2bfffa1247fc61d6c29f514de08c59bdfbac81e5))
* **client:** freeze models on property access ([69774cd](https://github.com/cjavdev/spotted-dotnet/commit/69774cddd2df0a6e0467789f35d9400df37e71df))
* **client:** throw api enum errors as invalid data exception ([fc525b0](https://github.com/cjavdev/spotted-dotnet/commit/fc525b0a067cad3a4c19600b64513d8e9429baef))
* **client:** use readonly type for param ([48b9312](https://github.com/cjavdev/spotted-dotnet/commit/48b9312ec1203a1a2aceda434fa9d071b3f92024))
* **internal:** don't try to push symbols to nuget as separate package ([89d16b3](https://github.com/cjavdev/spotted-dotnet/commit/89d16b3fed635e8137d136b89faf4635c21499fa))
* **internal:** remove redundant line ([c1c0eec](https://github.com/cjavdev/spotted-dotnet/commit/c1c0eec8ad54b6eae29a1f2b8cbc4bcc4aab002b))
* **internal:** remove roundtrip tests for multipart params ([2e1b3cf](https://github.com/cjavdev/spotted-dotnet/commit/2e1b3cfb769971b62713269f40936d2859571eac))
* **internal:** test nullability warnings ([34b7ec9](https://github.com/cjavdev/spotted-dotnet/commit/34b7ec9ae0d24a99d5e4fbf5af3e8d066de762b7))


### Performance Improvements

* **client:** add json deserialization caching ([2bfffa1](https://github.com/cjavdev/spotted-dotnet/commit/2bfffa1247fc61d6c29f514de08c59bdfbac81e5))


### Chores

* **client:** consistently use serializer options ([2b090b5](https://github.com/cjavdev/spotted-dotnet/commit/2b090b597e8893edfa0fa146e1545a2260baa299))
* **client:** refactor union instantiation ([55dec9f](https://github.com/cjavdev/spotted-dotnet/commit/55dec9f19948704be6379a86603fc655d8efff4e))
* **internal:** add files to sln so they show up in visual studio ([9cb64bc](https://github.com/cjavdev/spotted-dotnet/commit/9cb64bc232596c45e91c3861bd67ffb435ca701c))
* **internal:** share csproj properties with dir build props ([34b7ec9](https://github.com/cjavdev/spotted-dotnet/commit/34b7ec9ae0d24a99d5e4fbf5af3e8d066de762b7))
* **internal:** suppress a diagnostic ([8f86ff9](https://github.com/cjavdev/spotted-dotnet/commit/8f86ff9878cece4beb1657d3d15fa23251975c9f))
* **internal:** turn off overzealous lints ([1906b65](https://github.com/cjavdev/spotted-dotnet/commit/1906b652f15abbbcd0667e52b025534d07035014))
* **internal:** use better namespace aliases ([518f29c](https://github.com/cjavdev/spotted-dotnet/commit/518f29c9b11ac0028a32bd33cd50304e41203add))
* **internal:** use better test examples ([34b7ec9](https://github.com/cjavdev/spotted-dotnet/commit/34b7ec9ae0d24a99d5e4fbf5af3e8d066de762b7))
* **readme:** remove beta warning now that we're in ga ([d8f2ffb](https://github.com/cjavdev/spotted-dotnet/commit/d8f2ffb579cbece3ed6da2fbc088efd8495c5c95))
* rename some identifiers ([41fe823](https://github.com/cjavdev/spotted-dotnet/commit/41fe823c2ea9ce2983251eef00459c16f5e6adcb))


### Documentation

* add raw responses to readme ([25283bb](https://github.com/cjavdev/spotted-dotnet/commit/25283bbbf60b619a88a561e005b77168a1a51629))


### Refactors

* **client:** add `JsonDictionary` identity methods ([f8d1ff9](https://github.com/cjavdev/spotted-dotnet/commit/f8d1ff9920485126b435cf4f53e3fd99bdac0840))
* **client:** change casing of some identifiers ([745ac1e](https://github.com/cjavdev/spotted-dotnet/commit/745ac1e98e5e543abbcb645684c5e2e6b0f355a6))
* **client:** make unions implement `ModelBase` ([a268072](https://github.com/cjavdev/spotted-dotnet/commit/a268072e83d455bed4b52899bad95d6514f00012))
* **internal:** `JsonElement` constant construction ([66efad3](https://github.com/cjavdev/spotted-dotnet/commit/66efad367cd79a4fd94df50e596d5312da5016a0))

## 0.5.0 (2025-12-18)

Full Changelog: [v0.4.0...v0.5.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.4.0...v0.5.0)

### Features

* **api:** manual updates ([63a8e45](https://github.com/cjavdev/spotted-dotnet/commit/63a8e45822865e84390ad4f0dc9655428b849c17))
* **client:** add multipart form data support ([eeb5016](https://github.com/cjavdev/spotted-dotnet/commit/eeb50166e2aa99b6d9473d92ca2b4ff90869cff3))


### Documentation

* add contributing.md ([c0da39c](https://github.com/cjavdev/spotted-dotnet/commit/c0da39c381a6ee34aea7cd9a4de2e5c17b9d1a2c))

## 0.4.0 (2025-12-18)

Full Changelog: [v0.3.1...v0.4.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.3.1...v0.4.0)

### Features

* **api:** manual updates ([c232bb4](https://github.com/cjavdev/spotted-dotnet/commit/c232bb4926c1399eda57f9a8f678c941238c5810))
* **api:** manual updates ([cff2ed2](https://github.com/cjavdev/spotted-dotnet/commit/cff2ed273866a76ae5f7c549c5107d885121f3fc))
* **api:** manual updates ([320a6ed](https://github.com/cjavdev/spotted-dotnet/commit/320a6edfaafc24b43c333586419e4a8aad0fb18d))
* **client:** add EnvironmentUrl ([9bbc451](https://github.com/cjavdev/spotted-dotnet/commit/9bbc4516af6b050b180c79d9b13271f687a752ad))


### Chores

* **client:** improve object instantiation ([e7030a7](https://github.com/cjavdev/spotted-dotnet/commit/e7030a7daa9914c974d885b020cb3c848021e086))
* **client:** update test dependencies ([342fdd4](https://github.com/cjavdev/spotted-dotnet/commit/342fdd47993765b7e85ded77bc2f75dd07e18074))
* **internal:** use `Random.Shared` in newer .NET versions ([4cb035f](https://github.com/cjavdev/spotted-dotnet/commit/4cb035f661c8c5303d72cf6f4304e869fd6561fa))

## 0.3.1 (2025-12-12)

Full Changelog: [v0.3.0...v0.3.1](https://github.com/cjavdev/spotted-dotnet/compare/v0.3.0...v0.3.1)

### Bug Fixes

* **internal:** add nullability checks for tests ([35f0e7c](https://github.com/cjavdev/spotted-dotnet/commit/35f0e7c10e8c088c7a64018a1bc63f1101aeed2c))


### Chores

* **client:** improve union validation ([685acc5](https://github.com/cjavdev/spotted-dotnet/commit/685acc508de6f767f6ce29fc2f412bba1f1e6540))
* **internal:** add union tests ([41a69d6](https://github.com/cjavdev/spotted-dotnet/commit/41a69d6820533cb9bc9498d3aad820dcbd14db92))
* **internal:** codegen related update ([b65f903](https://github.com/cjavdev/spotted-dotnet/commit/b65f903b4c840be0b5e9f11699b7431cf73ffa73))

## 0.3.0 (2025-12-11)

Full Changelog: [v0.2.0...v0.3.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.2.0...v0.3.0)

### Features

* **api:** manual updates ([145a8dd](https://github.com/cjavdev/spotted-dotnet/commit/145a8dd6a676479271c6268a87e51785f25c03e5))
* **api:** manual updates ([8eeafa6](https://github.com/cjavdev/spotted-dotnet/commit/8eeafa6f1e0da2a4c8209f9472e1f06fd01e8d85))
* **api:** manual updates ([89b02ff](https://github.com/cjavdev/spotted-dotnet/commit/89b02ff2a692b41e7c26b07389f12ec84e75e396))
* **api:** manual updates ([dd96cb8](https://github.com/cjavdev/spotted-dotnet/commit/dd96cb8cbecd1f256d30be0c3c946334cec34454))
* **api:** manual updates ([755c30a](https://github.com/cjavdev/spotted-dotnet/commit/755c30a7f5c636ed5e7ff321a7162506870863cb))


### Bug Fixes

* **client:** handle floats correctly ([80fdecf](https://github.com/cjavdev/spotted-dotnet/commit/80fdecff16fa6b99c57a8b0b8375c2ee5d26640b))


### Chores

* **internal:** add enum tests ([47531d0](https://github.com/cjavdev/spotted-dotnet/commit/47531d0d2de7e175ec05fc45bae0873ecaaf089f))

## 0.2.0 (2025-12-08)

Full Changelog: [v0.1.0...v0.2.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.1.0...v0.2.0)

### Features

* **api:** api update ([4f9f56f](https://github.com/cjavdev/spotted-dotnet/commit/4f9f56ff77d28622063a12af1eaf19c77113b028))

## 0.1.0 (2025-12-05)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/cjavdev/spotted-dotnet/compare/v0.0.1...v0.1.0)

### Features

* **api:** Update readme titles. ([3884e00](https://github.com/cjavdev/spotted-dotnet/commit/3884e00ed8547130ec8fd1e24af0c27629f1ed31))
