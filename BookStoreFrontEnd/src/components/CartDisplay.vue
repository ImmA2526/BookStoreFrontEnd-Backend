<template>
  <div>
    <!-- <Home/> -->
    <b-card class="card">
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
              <button @click="updateCart()">&mdash;</button>
              <input type="text" :value="qnty" readonly />
              <button @click="updateCart()">&#xff0b;</button>
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
    </b-card>
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
      qnty: 1,
      bookId:null,
      bookCount:null,

    };
  },

 methods: {
    updateCart(cartId) {
      console.log(localStorage.getItem('UserId'));
      const bookData = {
        cartId,
        // bookId,
        booCount:this.bookCount,
        bookId:this.bookId,
        UserId:localStorage.getItem("UserId"),
        
      };
      // if(this.qnty===1){
      //   this.qnty++;
      // }
      // this.qnty--;
      console.log(this.bookData);
      bookService
      .updateCart(cartId,bookData)
      .then((response) => {
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
  left: 2px;
  width: 140px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 12px;
  text-align: center;
}
// Card
#display {
  margin-left: 8%;
  margin-top: 2%;
  width: 233px;
  border-radius: 2px 2px 0px 0px;
  opacity: 1;
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

#blank{
margin-top: 8px;
}
#blanks{
margin-top:18px;
}
#blanksbook{

}
#main-container {
  height: 80%;
  width: 80%;
  display: flex;
  flex-wrap: wrap;
  margin-left: 12%;
}

//Bookname Bg Color
#bookdiv {
  background-color: white;
  display: grid;
  text-align: left;
  font-size: 14px;
  margin-left: 18px;
  height: 10px;

  // word-break: break-all;
}

#bookcount {
  margin-top: -12px;
  margin-left: 8%;
  font-size: small;
  display: flex;
}

#count {
  font-size: 16px;
}

.card {
  position: relative;
  flex-direction: column;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 251px;
  top: 112px;
  left: 177px;
  width: 774px;
}

.card-body {
  flex: 1 1 auto;
  min-height: 1px;
  /* padding: 1.25rem; */
}
</style>
