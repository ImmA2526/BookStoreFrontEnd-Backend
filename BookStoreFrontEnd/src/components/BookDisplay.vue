<template>
  <div class="maindiv">
    <div id="bookcount">
      <h5>Books</h5>
      ({{ allBooks.length }} <label id="lb">Items </label>)

      <div id="drop">
        <b-dropdown id="item" text="Sort By Relevance" size="sm">
          <b-dropdown-item size="sm" id="items" href="#"
            >Price High To Low</b-dropdown-item
          >
          <b-dropdown-item size="sm" id="items" href="#"
            >Price Low To High</b-dropdown-item
          >
        </b-dropdown>
      </div>
    </div>

    <div id="main-container">
      <div id="display" class="card" v-for="book in allBooks" :key="book._id">
        <div class="img">
          <img v-bind:src="book.bookImage" />
        </div>

        <div id="bookdiv" class="book">
          <div class="bookname">
            <b>{{ book.bookName }}</b>
          </div>
          <div id="name">by {{ book.authorName }}</div>
          <div id="price"><b>RS:</b> {{ book.bookPrice }}</div>
        </div>

        <div class="btns" v-if="!display">
          <md-button
            type="button"
            id="add"
            v-on:click="
              AddCart(book.bookId);
              display = !display;
            "
            >ADD TO BAG</md-button
          >
          <md-button
            type="button"
            id="wish"
            v-on:click="AddWishlist(book.bookId)"
            >WISHLIST</md-button
          >
        </div>

        <div id="Addedbutton" v-if="display">
          <md-button id="added">ADDED TO BAG</md-button>
        </div>
        <!-- <Description/> -->
      </div>
    </div>
  </div>
</template>

<script>
import bookService from "../Services/bookService";
export default {
  name: "DisplayBooks",

  props: ["allBooks", "total"],

  data() {
    return {
      display: false,
      key:'',
      books: [],
      // total:'',
      Loadding: false,
      bookId: "",
      UserId: "",
      bookCount: 1,
    };
  },

  ///Add Books To Cart
  methods: {
    AddCart(bookId) {
      console.log(bookId);
      console.log(localStorage.getItem('UserId'));
      const bookData = {
        bookId,
        booCount:this.bookCount,
        key:bookId,
        UserId:localStorage.getItem("UserId"),
      };
      console.log(this.bookData);
      bookService
      .addBag(bookData)
      .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    //Add to Wishlist
    AddWishlist(bookId) {
      console.log(localStorage.getItem("UserId"));
      const bookData = {
        bookId,
        UserId: localStorage.getItem("UserId"),
      };
      console.log(this.bookData);
      bookService
        .addToWishlist(bookData)
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>

<style lang="scss" scoped>
#add {
  background-color: brown;
  height: 24px;
  margin-left: 16px;
  width: 90px;
  color: white;
  font-size: 10px;
  border: none;
}

//Bookname Bg Color
#bookdiv {
  background-color: white;
  display: grid;
  text-align: left;
}

#name {
  font-size: 4px;
}
.btns {
  display: flex;
  background-color: white;
}
#wish {
  font-size: 10px;
  height: 24px;
  width: 3;
  border: 1px solid black;
  margin-left: 10px;
}
// Card
#display {
  margin-left: 2%;
  margin-top: 2%;
  top: 20px;
  left: 120px;
  width: 233px;
  background: #f5f5f5 0% 0% no-repeat padding-box;
  border-radius: 2px 2px 0px 0px;
  opacity: 1;
}

.book {
  float: left;
  margin-left: 4px;
  background: #f5f5f5 0% 0% no-repeat padding-box;
}

.img {
  top: 163px;
  left: 239px;
  width: 105px;
  height: 135px;
  margin: auto;
  opacity: 1;
}

#main-container {
  height: 80%;
  width: 80%;
  display: flex;
  flex-wrap: wrap;
  margin-left: 12%;
}

#name {
  font-size: small;
  display: grid;
  margin-left: 8px;
}

#price {
  font-size: 12px;
  margin-left: 8px;
}

.bookname {
  font-size: 12px;
  margin-left: 8px;
}

#bookcount {
  margin-top: 80px;
  margin-left: 22%;
  display: flex;
}

//ITEMS
#lb {
  margin-left: 4px;
}

#drop {
  background-color: white;
  display: flex;
  margin-left: 720px;
}

//Other Device
@media (min-width: 360px) and(max-width:640px) {
  // Card

  #display {
    display: flex;
    margin-left: 6%;
    // margin-top: 20%;
    top: 20px;
    left: 20px;
    width: 240px;
    background: #f5f5f5 0% 0% no-repeat padding-box;
    border-radius: 2px 2px 0px 0px;
    opacity: 1;
  }

  #bookcount {
    margin-top: 80px;
    margin-left: 8%;
    display: flex;
  }

  .img {
    top: 13px;
    left: 29px;
    width: 105px;
    height: 135px;
    margin: auto;
    opacity: 1;
  }
  //ITEMS
  #lb {
    margin-left: 4px;
  }

  #drop {
    background-color: white;
    display: flex;
    margin-left: 50px;
    height: 34px;
  }
}

.btns {
  display: flex;
  background-color: white;
}
#wish {
  font-size: 10px;
  height: 20px;
  width: 20px;

  border: 1px solid black;
  margin-left: 6px;
}

#add {
  background-color: brown;
  height: 20px;
  margin-left: 20px;
  overflow-wrap: break-word;
  overflow: wrap;
  width: 50px;
  color: white;
  font-size: 10px;
  border: none;
}
#item {
  height: 30px;
  width: 40px;
  border: none;
  background-color: white;
  margin: auto;
  // font-size: 10px;
}

#items {
  font-size: 10px;
  margin: auto;
}

#added{
  width: 170px;
    background-color: rgb(83, 83, 255);
    color: white;
    height: 26px;
    vertical-align: center;
    /* text-align: center; */
    /* margin: auto; */
    font-size: 16px;
    text-align: center;
}
</style>
