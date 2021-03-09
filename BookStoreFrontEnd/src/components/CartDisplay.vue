<template>
  <div>
    <div class="card">
      <div id="bookcount">
        <h5 id="count">My Cart ({{ allBooks.length }})</h5>
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
          <div id="Qnty">
            <div class="quantity-toggle">
              <button @click="updateCart(book, 'less')">&mdash;</button>
              <input type="text" :value="book.bookCount" readonly />
              <button @click="updateCart(book, 'more')">&#xff0b;</button>
              <div
                type="button"
                @click="RemoveCartItem(book.cartId);EventBus.$emit(fetchBooks)"
                id="remove"
              >
                Remove
              </div>
            </div>
          </div>
          <!-- </div> -->
        </div>
      </div>
<div v-if="!display">
      <b-button
        id="button"
        variant="primary"
        @click="(ishidden = false), (display = !display)"
        >PLACE ORDER</b-button
      >
</div>
    </div>
    <div />
    <div id="card" v-if="!display">
      <label id="lbl">Customer Details</label>
    </div>
     <div id="space" ></div>
     <div id="card" v-if="!display">
      <label id="lbl1">Order Details</label>      
    </div>
<div id="maincard" v-if="display"><CST /></div>
  </div>
</template>

<script>
import CST from "../components/CustomerDetail";
import bookService from "../Services/bookService";
import {EventBus} from "../main"
export default {
  name: "DisplayBooks",
  props: ["allBooks", "total"],

  components: {
    CST,
  },
  data() {
    return {
      books: [],
      Loadding: false,
      bookId: "",
      bookCount: "",
      count: "",
      display: false,
      isHidden: true,
    };
  },

//Update Cart

  methods: {
    updateCart(book, oprator) {
      console.log(book);
      console.log(localStorage.getItem("UserId"));
      if (oprator === "more") {
        this.count = book.bookCount + 1;
        // bus.$emit.fetchBooks();
      // bus.$emit('fetchBooks');
      } else {
        this.count = book.bookCount - 1;
        // bus.$emit.fetchBooks();
      
      }
      const bookData = {
        cartId: book.cartId,
        bookCount: this.count,
        bookId: book.bookId,
        userId: localStorage.getItem("UserId"),
      };
      console.log(bookData);
      bookService
        .updateCart(bookData)
        .then((response) => {
          // this.$emit('fetchBooks');
          //Emitter 
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    },

fetchbooks:function(){
    this.getCartBooks();
},
    ///Remove Item From Cart
    RemoveCartItem(cartId) {
      console.log(localStorage.getItem("UserId"));
      console.log(this.cartId);
      bookService
        .removeCart(cartId)
        .then((response) => {
          alert("BookRemoved From Cart Sussefully...");
        EventBus.$emit('fetchBooks');

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
  margin-bottom: 10px;
  width: 140px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 12px;
  text-align: center;
  margin-left: 580px;
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

#card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 60px;
  top: 130px;
  left: 240px;
  width: 774px;
  min-width: 0;
}

#lbl {
  margin-top: 16px;
}

#lbl1 {
  margin-top: 16px;

}

#space
{
  margin-top: 14px;
}
#remove {
  margin-left: 20px;
}

#maincard {
  margin-top: 20px;
}

//Other Device
@media (min-width: 360px) and(max-width:640px) {
  // Card
.card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: auto;
  top: 110px;
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
  top: 130px;
  left: 40px;
  width: 274px;
  // min-width: 0;
}

//Button
#button {
  margin-bottom: 10px;
  width: 100px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 10px;
  text-align: center;
  margin-left: 80px;
}
}
</style>
