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
   name: "Books",
  data() {
    return {
      Loadding: false,
      books: [],
      // allBooks: [],
 isListEmpty: true,
      
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
          console.log(response.data);
          // console.log("This is Your Data");
          this.allBooks= response.data;
          this.Loadding = false;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  }, // Method

  // For All List
  mounted() {
    console.log("message");
    this.getAllBooks();
  },
}; // }Export MAin
</script>
