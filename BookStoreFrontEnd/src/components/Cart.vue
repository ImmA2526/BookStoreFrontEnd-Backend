<template>
  <div class="Books">
    <NavBar />
    <div id="empty" v-if="isListEmpty">
      <Spinner class="spin" id="custom-spinner" v-if="Loadding" />
    </div>
    <div class="display Book">
      <CartDisplay v-bind:allBooks="books"></CartDisplay>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.spin {
  margin-top: 80px;
}
</style>

<script>
import Spinner from "vue-simple-spinner";
import bookService from "../Services/bookService";
import CartDisplay from "../components/CartDisplay";
import NavBar from "../components/NavBar";
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
    NavBar,
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
  }, // Method

  // For All List
created() {
    console.log("message");
    this.getCartBooks();
  },
}; // }Export MAin
</script>

<style lang="scss" scoped>
.spin {
  margin-top: 80px;
}
</style>
