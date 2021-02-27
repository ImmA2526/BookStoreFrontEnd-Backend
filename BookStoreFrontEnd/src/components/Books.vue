<template>
  <div class="Books">
    <div id="empty" v-if="isListEmpty">
      <Spinner id="custom-spinner" v-if="Loadding" />
    </div>
    <div class="display Book">
      <Display v-bind:allBooks="books"></Display>
    </div>
  </div>
</template>

<script>
import Spinner from "vue-simple-spinner";
import bookService from "../Services/bookService";
import Display from "../components/Displaybooks";
export default {
  data() {
    return {
      Loadding: false,
      books: [],
      allbooks: [],
    };
  },

  components: {
    Display,
    Spinner,
  },

  methods: {
    getAllBooks: function() {
      this.Loadding = true;
      bookService
        .getBooks()
        .then((response) => {
          console.log(response.data.data);
          this.Loadding = false;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  }, // Method

  // For All List
  mounted() {
    this.getAllBooks();
  },
}; // }Export MAin
</script>
