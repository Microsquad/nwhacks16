import hug
import os
import mock

@hug.get('/get_objs')
def get_objs():
	return os.listdir('./objects')

@hug.get('/get_teapot')
def get_teapot():
	with open('./objects/teapot.obj') as content_file:
		#content = content_file.read()
		content = ""
		for line in content_file:
			content += line[:-2]
			content += "\n"
		return content
