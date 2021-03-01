<template>
    <div>
    <!-- <router-view/> -->
<Home/>
<Book/>
    </div>
</template>

<script>
import Book from "../components/Books"
import Home from "../components/NavBar"

export default {
    components:{
        Home,
        Book,
    }
}
</script>