<template>
  <div class="Books">
    <!-- <NavBar /> -->
    <div id="empty" v-if="isListEmpty">
      <Spinner class="spin" id="custom-spinner" v-if="Loadding" />
    </div>
    <div class="display Book">
      <CartDisplay @getBooks="fetchBooks" v-bind:allBooks="books"></CartDisplay>
    </div>
    <!-- <CustomerDetail/> -->
  </div>
</template>

<script>
import Spinner from "vue-simple-spinner";
import bookService from "../Services/bookService";
import CartDisplay from "../components/CartDisplay";
// import NavBar from "../components/NavBar";
import { EventBus } from '../main';

export default {
  name: "Books",
  data() {
    return {
      Loadding: false,
      allBooks: [],
      books: [],
      total: "",
      isListEmpty: true,
    };
  },

  components: {
    CartDisplay,
    Spinner,
    // NavBar,
  },

  methods: {
    getCartBooks: function() {
      this.Loadding = true;
      bookService
        .getCartBooks()
        .then((response) => {
          this.books = response.data.data;
          console.log(response);
          this.Loadding = false;
          this.total = this.books.length;
          console.log(this.total);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    // Emiting Method 
    fetchBooks:function(){
      this.getCartBooks();
    },
  }, // Method

  // For All List
created() {
   EventBus.$on(this.getCartBooks())   
    console.log("message");
    
  },
}; // }Export MAin
</script>

<style lang="scss" scoped>
.spin {
  margin-top: 80px;
}
</style>
