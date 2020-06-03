function jsonsTable(inputArray) {
    let html = '<table>\n'
    for (let row of inputArray) {
        const openingTagForRow = "\t\t<td>";
        const closingTagForRow = "</td>\n";

        let parsed = JSON.parse(row);
        html += '\t\t<tr>\n';
        html += openingTagForRow + parsed.name + closingTagForRow;
        html += openingTagForRow + parsed.position + closingTagForRow;
        html += openingTagForRow + parsed.salary + closingTagForRow;
        html += "\t</tr>\n";
    }

    html += '</table>'

    return html;
}