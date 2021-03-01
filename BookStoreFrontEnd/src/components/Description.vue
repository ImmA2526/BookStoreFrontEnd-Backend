<template>
     <b-col md="6" class="py-4 text-center">
        <!-- <b-button id="popover-3" variant="primary">Using slots</b-button> -->
        <b-popover target="popover-3" triggers="hover focus">
          <template >Description Of Books</template>
          {{allBooks.bookDescription}}} </b-popover>
      </b-col>
</template>

<script>
// import Display from "../components/Displaybooks";

export default {
   name: "Books",
  data() {
    
    return {
      Loadding: false,
      allBooks: [],
      books:[],
//       total:'',
//    isListEmpty: true,
      
    };
  },
  components: {
    // Display,
    // Spinner,
  },

};
  </script>