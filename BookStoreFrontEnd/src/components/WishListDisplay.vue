<template>
  <div>
    <!-- <Home/> -->
    <div class="card">
      <div id="bookcount">
        <h5 id="count">Wishlist Items ({{ allBooks.length }})</h5>
      </div>
      <div id="display" v-for="book in allBooks" :key="book._id">
        <div class="img">
          <div id="blanksbook"></div>
          <img v-bind:src="book.bookImage" />
        </div>
        <div id="bookdiv" class="book">
          <b>{{ book.bookName }}</b>
          by {{ book.authorName }}
          <b>RS: {{ book.bookPrice }}</b>
          <div id="blank"></div>
          <div type="button" @click="RemoveWishItem(book.wishId)" id="remove">
            Remove
          </div>
        </div>
      </div>
    </div>
    <div />
  </div>
</template>

<script>
import bookService from "../Services/bookService";
export default {
  name: "DisplayBooks",
  props: ["allBooks", "total"],

  components: {
  },
  data() {
    return {
      books: [],
      Loadding: false,
      bookId: "",
      bookCount: "",
      count: "",
    };
  },

  methods: {
    RemoveWishItem(wishId) {
      console.log(localStorage.getItem("UserId"));
      console.log(this.wishId);
      bookService
        .RemoveWishlistItem(wishId)
        .then((response) => {
          alert("Wishlist Item Removed Succesfully");
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
#Qnty {
  display: grid;
  padding-top: 10px;
}

#remove {
  margin-left: 60px;
  border: 1px solid grey;
  border-radius: 4px;
}
$border: 2px solid #ddd;

.quantity-toggle {
  display: flex;
  width: 10px;
  height: 40px;

  input {
    border: 1px solid black;
    width: 2rem;
    text-align: center;
    align-items: center;
    height: 1.4rem;
  }

  button {
    border: $border;
    background: #f5f5f5;
    color: rgb(0, 0, 0);
    font-size: 0.5rem;
    border-radius: 50%;
    height: 1.5rem;
    cursor: pointer;
  }
}

#button {
  top: -110px;
  width: 140px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  left: 76%;
  font-size: 12px;
  text-align: center;
}
// Card
#display {
  margin-left: 8%;
  margin-top: 1%;
  width: 233px;
  border-radius: 2px 2px 0px 0px;
  opacity: 1;
  height: auto;
  display: flex;
}

//Name Margin
.book {
  float: left;
  margin-left: 20px;
  background: #f5f5f5 0% 0% no-repeat padding-box;
}

.img {
  top: 192px;
  left: 213px;
  width: 65px;
  height: 85px;
  opacity: 1;
}

//Bookname Bg Color
#bookdiv {
  background-color: white;
  display: grid;
  text-align: left;
  font-size: 12px;
  margin-left: 18px;
}

#bookcount {
  margin-top: 12px;
  margin-left: 8%;
  margin-bottom: 6px;
  font-size: small;
  display: flex;
}

#count {
  font-size: 16px;
}

.card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: auto;
  top: 112px;
 left: 240px;
  width: 774px;
  min-width: 0;
}

//Other Device
@media (min-width: 360px) and(max-width:640px) {
  // Card
.card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: auto;
  top: 180px;
  left: 40px;
  width: 274px;
}
//Second Card 
#space
{
  margin-top: 14px;
}
#card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 60px;
  top: 200px;
  left: 40px;
  width: 274px;
  // min-width: 0;
}


}
</style>

