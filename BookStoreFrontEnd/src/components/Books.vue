<template>
  <div class="Books">
    <div id="empty" v-if="isListEmpty">
      <Spinner class="spin" id="custom-spinner" v-if="Loadding" />
    </div>
    <div class="display Book">
      <Display v-bind:allBooks="books" ></Display>

    </div>
  </div>
</template>

<style lang="scss" scoped>
.spin{
  margin-top:80px
}
</style>


<script>
import Spinner from "vue-simple-spinner";
import bookService from "../Services/bookService";
import Display from "../components/Displaybooks";

export default {
   name: "Books",
  data() {
    
    return {
      Loadding: false,
      allBooks: [],
      books:[],
      total:'',
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
          this.books= response.data.data;
                   console.log(this.books);
          this.Loadding = false;
          this.total=this.books.length;
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
    this.getAllBooks();
  },
}; // }Export MAin
</script>
