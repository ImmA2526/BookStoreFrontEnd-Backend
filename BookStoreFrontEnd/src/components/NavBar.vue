<template>
  <div>
    <div class="main">
      <nav class="color" id="md-app">
        <div class="container-fluid">
          <form class="d-flex">
            <div id="book-div">
              <svg type="button"
              to="/home/Book"
                xmlns="http://www.w3.org/2000/svg"
                width="28"
                height="28"
                fill="white"
                class="bi bi-book"
                viewBox="0 0 16 16"
              >
                <path
                  d="M1 2.828c.885-.37 2.154-.769 3.388-.893 1.33-.134 2.458.063 3.112.752v9.746c-.935-.53-2.12-.603-3.213-.493-1.18.12-2.37.461-3.287.811V2.828zm7.5-.141c.654-.689 1.782-.886 3.112-.752 1.234.124 2.503.523 3.388.893v9.923c-.918-.35-2.107-.692-3.287-.81-1.094-.111-2.278-.039-3.213.492V2.687zM8 1.783C7.015.936 5.587.81 4.287.94c-1.514.153-3.042.672-3.994 1.105A.5.5 0 0 0 0 2.5v11a.5.5 0 0 0 .707.455c.882-.4 2.303-.881 3.68-1.02 1.409-.142 2.59.087 3.223.877a.5.5 0 0 0 .78 0c.633-.79 1.814-1.019 3.222-.877 1.378.139 2.8.62 3.681 1.02A.5.5 0 0 0 16 13.5v-11a.5.5 0 0 0-.293-.455c-.952-.433-2.48-.952-3.994-1.105C10.413.809 8.985.936 8 1.783z"
                />
              </svg>
              <button text="Book Store" to="./home" size="sm" id="book" >Book Store</button>

              <!-- <label type="button" to="./" id="book">Book Store</label> -->
            </div>
            <input
              id="search"
              class="form-control me-1"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <div id="cart-div">
              <!-- <b-button id="cart" to="./Cart">Cart</b-button> -->
              <svg
                id="carts"
                xmlns="http://www.w3.org/2000/svg"
                width="20"
                height="20"
                fill="white"
                class="bi bi-cart3"
                viewBox="0 0 16 16"
              >
                <path
                  d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .49.598l-1 5a.5.5 0 0 1-.465.401l-9.397.472L4.415 11H13a.5.5 0 0 1 0 1H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l.84 4.479 9.144-.459L13.89 4H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"
                />
              </svg>
              <b-button to="/home/cart" size="sm" id="cart" >Cart</b-button>

              <div id="wish-div">
                <svg
                  id="wishi"
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="20"
                  fill="currentColor"
                  class="bi bi-bookmark-heart"
                  viewBox="0 0 16 16"
                >
                  <path
                    fill-rule="evenodd"
                    d="M8 4.41c1.387-1.425 4.854 1.07 0 4.277C3.146 5.48 6.613 2.986 8 4.412z"
                  />
                  <path
                    d="M2 2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v13.5a.5.5 0 0 1-.777.416L8 13.101l-5.223 2.815A.5.5 0 0 1 2 15.5V2zm2-1a1 1 0 0 0-1 1v12.566l4.723-2.482a.5.5 0 0 1 .554 0L13 14.566V2a1 1 0 0 0-1-1H4z"
                  />
                </svg>
                <b-button to="/home/wish" size="sm" id="wish" >Wishlist</b-button>
              </div>
            </div>
          </form>
        </div>
      </nav>
    </div>
    <!-- <router-view></router-view> -->
  </div>
</template>

<style lang="scss" scoped>



.main {
  display: flex;
  // justify-content: center;
}
  //AppBar
  #md-app {
    padding-left: 0px;
    position: fixed;
    width: 100%;
    overflow: hidden;
    z-index: 1000;
    display: flex;
    justify-items: center;
  }


  #bookcount {
    margin-top: 20px;
  }


  // Navabar Style
  .color {
    background-color: rgb(192, 56, 56);
    height: 8%;
  }

//BookStore
  #book-div {
    padding-left: 4%;
    height: 10px;
    margin-top: 14px;
    width: 40%;    
  }

#book {
     color: white;
    font-size: 14px;
    margin-left: 2%;
    background-color: rgb(192, 56, 56);
    border: none;

    }
  #wish-div {
    margin-top: -34px;
    color: white;
    margin-left: 80px;
    display: grid;
    width: 10px;
  }

  #wishi {
    margin-left: 20px;
  }

  #wish {
    font-size: 12px;
    margin-left: 4%;
    height: 18px;
    border: none;
    text-decoration: none;
    outline: none;
    color: white;
    background-color: #c03838;
    display: grid;
  }
  //Cart

  #cart-div {
    padding-left: 4%;
    margin-top: 12px;
    margin-right: 400px;
    width: 10px;
    margin-left: 80px;


  }

    #cart {
      font-size: 12px;
      margin-right: 4%;
      height: 18px;
      border: none;
      text-decoration: none;
      outline: none;
      color: white;
      background-color: #c03838;
      display: grid;
    }

    #carts {
      margin-left: 10px;
    }

//Search
  #search {
    height: 10%;
    margin-top: 14px;
    width: 40%;
    border-radius: 4px;
    border-style: none;
  }

@media (min-width: 360px) and(max-width:640px) {
  // Card
#search
{
      width: 120px;
    margin-left: 6px;
}

#carts{
  margin-left: -140px;
  margin-top: -10px;
}

#cart{
  width: 20px;
  margin-left: -90px;
  margin-top: -8px;
}

 #wishi {
    margin-left: -110px;
    margin-top: -4px;
  }

  #wish {
     margin-left: -130px;
     width: 20px;
   }

 #book-div {
    padding-left: 6px;
    height: 6px;
    margin-top: 14px;
    display: flex;
    width: 110px;    
  }

#book {
     color: white;
    font-size: 12px;
    margin-left: 2px;
     margin-top: 4px;
    width: 80px;
    background-color: rgb(192, 56, 56);
    border: none;

    }

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
