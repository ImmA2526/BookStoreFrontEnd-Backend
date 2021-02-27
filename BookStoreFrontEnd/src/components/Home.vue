<template>
  <!-- Main -->
  <div>
    <!-- <Home></Home> -->
    <div class="text">
      <md-app md-mode="reveal">
        <md-app-toolbar class="color" position="fixed">
          <!-- <md-button class="md-icon-button">
            <md-icon>menu</md-icon>
          </md-button>
          <span class="md-title">Keep</span>
 -->
          <md-card id="cards">
            <md-icon id="search">search</md-icon>
            <input type="text" class="textbox" placeholder="Search" />
          </md-card>

          <!-- <!-- <div class="Icons"> -->
            <md-icon id="refresh">refresh</md-icon>
            <md-icon id="listview">view_stream</md-icon>
            <md-icon id="setting">settings</md-icon>
            <md-icon id="apps1" class="material-icons">apps</md-icon>
          </div> -->
        </md-app-toolbar>
      </md-app>
    </div>
  </div>
  <!-- </div> -->
  <!-- Main -->
</template>

<style lang="scss" scoped>
// Navabar Style
.color {
  background-color: #fff;
  height: 20px;
}

#cards {
  height: 40px;
  width: 560px;
  border-radius: 10px;
  // border:0.1px solid black;
  margin-left: 200px;
}

.textbox {
  width: 420px;
  border-radius: 12px;
  height: 36px;
  margin-top: 2px;
  outline: none;
  margin-right: 70px;
  border: none;
}

.text {
  display: inline;
  height: 20px;
}

.Icons {
  display: inline;
  margin-left: 240px;
}
#search {
  // margin-left: 24px;
  color: black;
  margin-right: 12px;
}
#listview {
  margin-left: 24px;
}
#setting {
  margin-left: 24px;
  color: black;
}
#apps1 {
  margin-left: 110px;
  color: black;
}

.title {
  font-size: 20px;
  font-weight: normal;
  margin-top: 20px;
  cursor: pointer;
}
.title-name {
  font-weight: bold;
  margin-right: 200px;
}
#refresh {
  margin-left: 24px;
  color: black;
}

// @media (min-width: 100px) and (max-width: 140px) {
// .md-app-toolbar , .md-app-bar
//    {
//     width: 100px;
//     left: 15vw;
//   }
//   .md-app-toolbar {
//     position: fixed;
//     top: 0;
// }

//   }
</style>

<script>
// Importing One Component To Another
// import Create from "../components/Create";
// import Home from "../components/Home";
export default {
  components: {
    // Create,
    // Home,
    // Display,
  },
  name: "Reveal",
  data: () => ({
    menuVisible: false,
  }),
  // methods: {
  //   toggleMenu() {
  //     this.menuVisible = !this.menuVisible;
  //   },
  // },
};
</script>
