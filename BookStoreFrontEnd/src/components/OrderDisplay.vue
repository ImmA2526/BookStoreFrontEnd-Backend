<template>
  <div>
    <!-- <Home/> -->
    <div class="card">
      <div id="bookcount">
        <h5 id="count">Order ({{ allBooks.length }})</h5>
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
         </div>
      </div>

      <b-button
        id="button"
        variant="primary"
       v-on:click="CheckoutOrder()">CHECK OUT</b-button
      >
    </div>
    <div />
    </div>
</template>

<script>
// import CST from "../components/CustomerDetail";
import bookService from "../Services/bookService";
export default {
  name: "DisplayBooks",
  props: ["allBooks", "total"],

  components: {
    // CST,
  },
  data() {
    return {
       display: false,
      books: [],
      Loadding: false,
      bookId: "",
      bookCount: "",
      count: "",
     orderSummaryID:'',
      isHidden: true,
    };
  },

//Update Cart

  methods: {
      CheckoutOrder() {
      console.log(localStorage.getItem('UserId'));
      const bookData = {
       
        UserId:localStorage.getItem("UserId"), 
      };
      console.log(this.bookData);
      bookService
      .orderCheckout(bookData)
      .then((response) => {
        alert("Order Added Succesfully");
        this.$router.push("/success");
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
  left: 177px;
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
  margin-top: 8px;
  font-size: 10px;
  text-align: center;
  margin-left: 140px;
}
}
</style>