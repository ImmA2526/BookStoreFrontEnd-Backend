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

        <!-- <div class="btns">
          <md-button type="button" id="add" v-on:click="AddCart(book.bookId)"
            >ADD TO BAG</md-button
          >
          <md-button type="button" id="wish">WISHLIST</md-button>
        </div> -->
        <!-- <Description/> -->
      </div>
    </div>
  </div>
</template>

<script>
// import bookService from "../Services/bookService";
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
      // bookId: "",
      // UserId:'',
      // bookCount: 1,
    };
  },
  
  // methods: {
  //   AddCart(bookId) {
  //     console.log(localStorage.getItem('UserId'));
  //     const bookData = {
  //       bookId,
  //       booCount:this.bookCount,
  //       UserId:localStorage.getItem("UserId"),
        
  //     };
  //     console.log(this.bookData);
  //     bookService
  //     .addBag(bookData)
  //     .then((response) => {
  //         console.log(response);
  //       })
  //       .catch((error) => {
  //         console.log(error);
  //       });
  //   },
  // },
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
  overflow-wrap:break-word;
  overflow: wrap;
  width: 50px;
  color: white;
  font-size: 10px;
  border: none;
}

</style>
