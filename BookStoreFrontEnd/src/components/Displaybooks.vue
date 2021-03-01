<template>
  <div class="maindiv">
    <div id="bookcount">
      <h5>Books</h5>
      ({{ allBooks.length }} <label id="lb">Items </label>)

      <div class="dropdown">
        <button
          class=" btn-sm dropdown-toggle"
          type="button"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
          id="drop"
        >
          Sort By Relevance
        </button>
        <div class="dropdown-menu" aria-labelledby="Sort By Relevance">
          <a class="dropdown-item" href="#"></a>
          <a class="dropdown-item" href="#">Another action</a>
          <a class="dropdown-item" href="#">Something else here</a>
        </div>
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

        <div class="btns">
          <md-button type="button" id="add" v-on:click="AddCart()" >ADD TO BAG</md-button>
          <md-button type="button" id="wish">WISHLIST</md-button>
        </div>
        <!-- <Description/> -->
      </div>
    </div>
  </div>
</template>

<script>
import bookService from "../Services/bookService";
// import Description from './Description.vue';
export default {
  name: "DisplayBooks",
  // components: {Description},

  props: ["allBooks", "total"],

  data() {
    return {
      books: [],
      // total:'',
      Loadding: false,
      bookId: "",
      userId: "",
    };
  },

  methods: {
    AddCart() {
      const bookData = {
        bookId: this.bookId,
        userId: "",
      };
      bookService
      .addBag(bookData)
        .then((data) => {
          console.log(data);
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
  width: 90px;
  color: white;
  font-size: 10px;
  border: none;
}

//Bookname Bg Color
#bookdiv {
  background-color: white;
  display: grid;
  // float: left;
  // text-align: justify;
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
  margin-left: 2px;
}
// Card
#display {
  width: 18%;
  height: 24%;
  display: inline-flex;
  margin-left: 2%;
  margin-top: 2%;
  background-color: lightgray;
}

#RS {
}
.book {
  float: left;

  //  margin-right: 18%;
  //  width: fit-content;
}

.img {
  // display: flex;
  // height: 4%;
  background-color: lightgray;
  padding-top: 4%;
  padding-bottom: 4%;
  margin: auto;
  width: 50%;
  height: 10%;
}

#main-container {
  // padding-top: 1%;
  height: 80%;
  width: 80%;
  display: flex;
  flex-wrap: wrap;
  // justify-content: center;
  margin-left: 12%;
  // margin-right: 16%;
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
  text-align: left;
  margin-left: 14%;
  display: flex;
  // margin-right: 200px;
}

#lb {
  margin-left: 4px;
}

#drop {
  background-color: white;
  display: flex;
  margin-left: 800px;
}

//Other Device
@media (min-width: 360px) and(max-width:640px) {
  // Card
  #display {
    float: left;
    width: 40%;
    height: 100%;
    display: inline-flex;
    flex-wrap: wrap;
    margin-left: 2%;
    margin-top: 2%;
    background-color: lightgray;
  }

  .book {
    float: left;
  }

  .img {
    // display: flex;
    // height: 4%;
    background-color: lightgray;
    padding-top: 4%;
    padding-bottom: 4%;
    margin: auto;
    width: 60%;
    height: 10%;
  }

  #main-container {
    // padding-top: 1%;
    height: 100%;
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    // justify-content: center;
    margin-left: 12%;
    // margin-right: 16%;
  }
}
</style>
