<template>
  <!-- Main -->
  <div>
    <!-- <Home></Home> -->
    <div class="main">
      <md-app md-mode="fixed">
        <md-app-toolbar fixed app flat class="color" >
          <div id="book-div">
            <img id="img" src="/book.png" />
            <label id="book">Book Store</label>
          </div>
          <div class="search">
            <!-- <md-card id="cards"> -->
            <md-icon id="search"
              >search <input type="text" class="textbox" placeholder="Search"
            /></md-icon>

            <!-- </md-card> -->
          </div>

          <div class="Icons">
            <label>Cart</label>
            <md-icon id="cart">shopping_cart</md-icon>
          </div>
        </md-app-toolbar>
      </md-app>
      <!-- <p>OK</p> -->
          <router-view></router-view>
        
    </div>
  </div>
  <!-- </div> -->
  <!-- Main -->
</template>

<style lang="scss" scoped>
// Navabar Style
.color {
  background-color: rgb(192, 56, 56);
  height: 10px;
}

#search {
  height: 40px;
  width: 500px;
  display: flex;
  justify-content: center;
  margin-left: 100px;

  .search {
    color: black;
    margin-right: 12px;
    height: 20px;
    display: inline-block;
  }

  .textbox {
    width: 500px;
    height: 30px;
    margin-top: 4px;
    outline: none;
    margin-right: 70px;
    border: none;
    display: flex;
    justify-content: center;
  }

  // margin-left: 80px;
}

.Icons {
  display: inline;
  // margin-left: 100px;
  padding-left: 300px;

  color: white;
}

#cart {
  margin-left: 10px;
  color: white;
  cursor: pointer;
}

.main {
  height: 10px;
}

#book-div {
  // margin-left: 180px;
  padding-left: 200px;
}

#book {
  color: white;
  font-size: 16px;
}

#img {
  height: 20px;
  margin-right: 10px;
  cursor: pointer;
}
</style>

<script>
// import Home from "../components/Home";
export default {
  components: {
    // Home,
  },
};
</script>
