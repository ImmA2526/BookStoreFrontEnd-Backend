<template>
  <div id="display-book-container">
    <div id="display" class="card" v-for="book in allBooks" :key="book._id">
      <div class="addBook">
        <div class="books">
        <div class="img">
        <img src={book.bookImage}/>
        </div>  
                <div class="book pds">
            <b>{{ book.bookName }}</b>
          </div>
          <div class="book pds">RS: {{ book.bookPrice }}</div>

          <div class="book pds">
            <b>{{ book.authorName }}</b>
          </div>
          <!-- <div class="book pds">
            {{ book.bookPrice }}
          </div> -->

          <div class="book pds">
            <!-- <img src="{{book.BookImage}}" /> -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "DisplayBooks",
  components: {
    
  },

  props: ['allBooks'],

  data() {
    return {
      books:[],
    //   BookName: false,
    //   BookId: false,
    //   AuthorName: false,
    //   BookPrice: false,
    //   BookCount: false,
    //   BookImage: false,
    //   showDialog: false,
      Loadding: false,
    };
  },

};
</script>

<style lang="scss" scoped>
#display {
  display: flex;
  width: 240px;
  overflow-wrap: break-word;
  content: "";
  display: table;
  clear: both;
  margin: -16px -4px;
  display: inline-flex;
  white-space: normal;
  margin-left: 1%;
  margin-top: 3%;
}

.addBook {
  width: 240px;
  height: max-content;
  margin: 5px;
  border: 1px solid #dadce0;
  border-radius: 8px;
  box-sizing: content-box;
}

.books {
  height: fit-content;
  overflow: content;
}

// Spacing between word and line
.pds {
  letter-spacing: 0.00625em;
  padding: 5px;
  height: fit-content;
}

#display-book-container {
  width: 65vw;
  left: 10vw;
  position: relative;
  top: 2vh;
  color: black;
}
</style>
