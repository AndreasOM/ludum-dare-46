#/usr/bin/env sh
cwd=$(cd "$(dirname "$1")"; pwd)/$(basename "$1")
#echo $cwd

blender='/Applications/Blender.app/Contents/MacOS/Blender'
assets=${cwd}'unity/KeepItAlive/Assets'

#echo $assets

function object2fbx() {
	blendfile=$1
	name=$2
	filename=$3

	echo $blendfile $name $filename
#	r=$(echo ${blender} ${blendfile} --background --python tools/object2fbx.py -- \'${name}\' \'${filename}\')
	r=$(${blender} ${blendfile} --background --python tools/object2fbx.py -- ${name} ${filename})
#	echo ${r}
}

#object2fbx Content/items.blend 'ArrowUp' '//../arrow-up.fbx'
object2fbx Content/items.blend 'ArrowUp' $assets'/Items/arrowup.fbx'
object2fbx Content/items.blend 'WaterDrop' $assets'/Items/waterdrop.fbx'
object2fbx Content/Items/items.blend 'EnemyPendulum' $assets'/Items/EnemyPendulum.fbx'

#$(blender Content/items.blend --background --python tools/object2fbx.py -- 'ArrowUp' '//arrow-up.fbx')