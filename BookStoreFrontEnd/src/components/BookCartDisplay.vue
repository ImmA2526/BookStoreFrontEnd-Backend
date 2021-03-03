<template>
  <div>
    <!-- <Home/> -->
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
            </div>
          </div>
          <!-- </div> -->
        </div>
      </div>

      <b-button
        id="button"
        style="margin-top: 12%; float:right; position: relative"
        variant="primary"
        >PLACE ORDER</b-button
      >
      <b-card-text> </b-card-text>
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
      books: [],
      Loadding: false,
      // bookId:'',
      // bookCount:'',
      count: null,
    };
  },

  methods: {
    updateCart(book, oprator) {
      console.log(book, oprator);
      // const bookData = {
      //   bookCount:book.bookCount,
      //   bookId:book.bookId,
      // };
      // console.log(bookData);

     if (this.quantity === 1) {
        alert("Negative quantity not allowed");
      }

      if (oprator === "more") {
        this.count = book.bookCount++;
      } else {
        this.count = book.bookCount--;
      }
      console.log(this.count);
      bookService
        .updateCartBookQnty(this.count, book.bookId)
        .then((response) => {
          this.$emit("Cart");
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },

  //   increment() {
  //     this.quantity++;
  //   },
  //   decrement() {
  //     if (this.quantity === 1) {
  //       alert("Negative quantity not allowed");
  //     } else {
  //       this.quantity--;
  //     }
  //   },
  // },
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

// #blank{
// margin-top: 8px;
// }
// #blanks{
// margin-top:18px;
// }
// #blanksbook{

// }
// #main-container {
//   height: 80%;
//   width: 80%;
//   display: flex;
//   flex-wrap: wrap;
//   margin-left: 12%;
// }

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
  // flex-direction: column;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: auto;
  top: 112px;
  left: 177px;
  width: 774px;
  // position: relative;
  // display: flex;
  // flex-direction: column;
  min-width: 0;
}

// .card-body {
//   flex: 1 1 auto;
//   min-height: 1px;
//   /* padding: 1.25rem; */
// }
</style>
