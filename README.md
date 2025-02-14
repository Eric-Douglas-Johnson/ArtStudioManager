# ArtStudioManager

<!---
<img src="https://ai.github.io/size-limit/logo.svg" align="right"
     alt="Size Limit logo by Anton Lovchikov" width="120" height="178">
-->

The goal of the ArtStudioManager project is to provide solutions for day-to-day art studio management tasks, prioritizing:
1. The minimization of time and effort required to complete those tasks.
2. Revenue generation.

## Code Architecture

* Data persistence is decoupled from concrete storage medium--realized through interfaces for loading and saving.
* Model instantiation must be done through a factory.
* A data loader type must be injected into factory methods that instantiate models from stored data.
* All model instances will be identified uniquely by a Guid.
* If a model is saved as a file, it is required that the name of the file be equal to string representation of the model's identifier.

## Features

* Send batched emails.
* Create and manage art classes.
* Post content to Facebook.
* Manage member, patron, and art buyer/customer accounts.
* Process payment transactions for classes, purchases, and donations.
* Manage art supplies and inventory.
* 
## Usage

### Class Creation

<details><summary><b>Show instructions</b></summary>

1. Click `Classes` in the main menu:

    <img src="./wwwroot/images/main-menu-classes.png" width="738">

2. Click `Add New Class` button:

     <img src="./wwwroot/images/classes-addnew-btn.png" width="738">

3. Enter class information into fields:

    <img src="./wwwroot/images/addnew-class-page.png" width="738">

</details>

<!---
## Reports

Size Limit has a [GitHub action] that comments and rejects pull requests based
on Size Limit output.

1. Install and configure Size Limit as shown above.
2. Add the following action inside `.github/workflows/size-limit.yml`

```yaml
name: "size"
on:
  pull_request:
    branches:
      - master
jobs:
  size:
    runs-on: ubuntu-latest
    env:
      CI_JOB_NUMBER: 1
    steps:
      - uses: actions/checkout@v1
      - uses: andresz1/size-limit-action@v1
        with:
          github_token: ${{ secrets.GITHUB_TOKEN }}
```

## Config

### Limits Config

Size Limits supports three ways to define limits config.

1. `size-limit` section in `package.json`:

   ```json
     "size-limit": [
       {
         "path": "index.js",
         "import": "{ createStore }",
         "limit": "500 ms"
       }
     ]
   ```

<p align="center"> 
  <img src="./img/example.png" alt="Size Limit CLI" width="738">
  https://github.com/Eric-Douglas-Johnson/ArtStudioManager/blob/main/wwwroot/images/main-menu.png
</p>

With `--why`, Size Limit can tell you *why* your library is of this size
and show the real cost of all your internal dependencies.
We are using [Statoscope] for this analysis.

<p align="center">
  <a href="https://evilmartians.com/?utm_source=size-limit">
    <img src="https://evilmartians.com/badges/sponsored-by-evil-martians.svg"
         alt="Sponsored by Evil Martians" width="236" height="54">
  </a>
</p>

[Statoscope]:    https://github.com/statoscope/statoscope
[Storeon]: https://github.com/ai/storeon/
[Nano ID]: https://github.com/ai/nanoid/
[React]: https://github.com/facebook/react/

## Who Uses ArtStudioManager

* [MobX](https://github.com/mobxjs/mobx)
* [Material-UI](https://github.com/callemall/material-ui)
* [Ant Design](https://github.com/ant-design/ant-design/)
* [Autoprefixer](https://github.com/postcss/autoprefixer)
-->
