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
import Display from "../components/Cart";

export default {
   name: "Books",
  data() {
    
    return {
      Loadding: false,
      allBooks: [],
      books:[],
      UserId:'',
   isListEmpty: true,
      
    };
  },

  components: {
    Display,
    Spinner,
  },



methods: {
    getCart: function() {
      this.Loadding = true;
      bookService
        .getCartBooks()
        .then((response) => {
          // this.books= response.data.data;
                   console.log(response);
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
    this.getCart();
  },
}; // }Export MAin
</script>
