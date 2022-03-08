
import json
import xlrd

# Give the location of the file

map_dict = {
    "player1": [ 30, 30 ],
    "player2": [ 700, 30 ],
    "snakes": { "Snake1": [ 60, 430 ] },
    'destructableBlocks':{},
    'indestructableBlocks':{},
}
wb = xlrd.open_workbook("sample.xls", formatting_info=True)
ws = wb.sheet_by_index(0)
# cif = ws.cell_xf_index(1,2)
# iif = wb.xf_list[cif]
# cbg = iif.background.pattern_colour_index
# print(cbg)


#first ele is the number (rows), second is the alpha (col), all start from 0

item_color_dir = {8: 'destructableBlocks', 22:'indestructableBlocks'}
for i in range(12):
    for j in range(20):
        cif = ws.cell_xf_index(i,j)
        iif = wb.xf_list[cif]
        cbg = iif.background.pattern_colour_index
        if item_color_dir.keys().__contains__(cbg):
            item = item_color_dir[cbg]
            map_dict[item][str(len(map_dict[item]))] = [j*40,i*40]




with open('initial_map0.json', 'w') as outfile:
    person_json = json.dump(map_dict,outfile)

# Output: {"name": "Bob", "age": 12, "children": null}

