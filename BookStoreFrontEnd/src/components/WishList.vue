<template>
  <div class="Books">
    <NavBar />
    <div id="empty" v-if="isListEmpty">
      <Spinner class="spin" id="custom-spinner" v-if="Loadding" />
    </div>
    <div class="display Book">
      <WishListDisplay v-bind:allBooks="books"></WishListDisplay>
    </div>
    <!-- <CustomerDetail/> -->
  </div>
</template>

<script>
import Spinner from "vue-simple-spinner";
import bookService from "../Services/bookService";
import WishListDisplay from "../components/WishListDisplay";
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
    WishListDisplay,
    Spinner,
    NavBar,
  },

  methods: {
    getWishListBooks: function() {
      this.Loadding = true;
      bookService
        .getWishListBooks()
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
mounted() {
    console.log("message");
    this.getWishListBooks();
  },
}; // }Export MAin
</script>

<style lang="scss" scoped>
.spin {
  margin-top: 80px;
}
</style>
