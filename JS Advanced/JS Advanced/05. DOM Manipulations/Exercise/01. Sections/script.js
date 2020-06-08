function create(words) {
   let contentDiv = document.getElementById("content");

   for (const word of words) {
      let newDiv = document.createElement("div");
      let newParagraph = document.createElement("p");

      newParagraph.innerText = word;
      newParagraph.style.display = "none";
      newDiv.appendChild(newParagraph)

      newDiv.addEventListener("click", divOnClick)

      contentDiv.appendChild(newDiv);
   }

   function divOnClick(e) {
      e.target.children[0].style.display = "block";
   }
}