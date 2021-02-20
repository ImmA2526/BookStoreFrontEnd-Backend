<template>
  <div class="page-container">
    <Nav></Nav>
    <md-app id="tb">
      <div class="ChildNote">
        <Note AllNotes=""></Note>
      </div>
      <!-- Toolbaar>> File Menue -->
      <md-app-toolbar id="tb" class="md-primary" md-elevation="0">
        <md-button class="md-icon-button" @click="toggleMenu" v-if="!menuVisible">
          <md-icon id="tb1">keyboard_arrow_right</md-icon>
        </md-button>
      </md-app-toolbar>

      <md-app-drawer id="tb" :md-active.sync="menuVisible" md-persistent="mini">
        <md-toolbar id="tb" class="md-transparent" md-elevation="0">

          <div class="md-toolbar-section-end">
            <md-button class="md-icon-button md-dense" @click="toggleMenu">
              <md-icon id="mn">keyboard_arrow_left</md-icon>
            </md-button>
          </div>

        </md-toolbar>

        <md-list id="tb">
          <md-list-item>
            <md-icon id="notes">notes</md-icon>
            <span id="notes" class="md-list-item-text">Notes</span>
          </md-list-item>

          <md-list-item>
            <md-icon id="reminder">notifications</md-icon>
            <span id="reminder" class="md-list-item-text">Reminders</span>
          </md-list-item>

          <md-list-item>
            <md-icon id="archive">archive</md-icon>
            <span id="archive" class="md-list-item-text">Archive</span>
          </md-list-item>

          <md-list-item>
            <md-icon id="delete">delete</md-icon>
            <span id="delete" class="md-list-item-text">Trash</span>
          </md-list-item>
        </md-list>

      </md-app-drawer>

      <md-app-content>
        <!-- <Create></Create> -->
        <!-- <Display ></Display> -->
<Note />
      </md-app-content>
    </md-app>
  </div>
</template>

<script>
// Importing One Component To Another
// import Create from "../components/Create";
// import Create from "../components/Create"
// import Display from '../components/Display.vue'
import Nav from "../components/NavBar";
import Note  from "../components/Note";
export default {
  components: {
    Nav,
    // Create,
    // Display,
    Note,
  },
  name: "PersistentMini",
  data: () => ({
    menuVisible: false,
  }),

  methods: {
    toggleMenu() {
      this.menuVisible = !this.menuVisible;
    },
  },
};
</script>

<style lang="scss" scoped>
.md-app {
  min-height: 350px;
}

.home {
  color: black;
}

.tabs {
  color: black;
}
#tb1 {
  color: black;
}
// Demo purposes only
.md-drawer {
  width: 230px;
  // max-width: calc(100vw - 125px);
  height: 700px;
}

.md-content {
  height: 650px;
  color: black;
}

#log {
  color: black;
}

#home {
  color: black;
}

// navigation
#tb {
  background-color: white;
}

#delete {
  color: black;
}

#archive {
  color: black;
}

#reminder {
  color: black;
}

#notes {
  color: black;
}

#home {
  color: black;
}

#log {
  position: absolute;
  color: black;
}

#mn {
  color: black;
}

</style>